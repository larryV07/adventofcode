using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public int[] RibbonHash(int[] lengths) {
    int[] list = new int[256];
    for(int i = 0; i<list.Length; i++) list[i] = i;
    int skip = 0;
    int pos = 0;

    for(int k=0; k<64; k++) {
        foreach(int len in lengths) {
            int start=pos, end = (pos+len-1 + 256) % 256;

            for(int i=0, j=len-1; i<=j; i++, j--) {
                int temp = list[(i+start)%256];
                list[(i+start)%256] = list[(j+start)%256];
                list[(j+start)%256] = temp;
            }

            pos = (pos + len + skip) % 256;
            skip++;
        }
    }

    return list;
}

public int XOR16(int[] nums) {
    int res = nums[0];
    for(int i=1; i<nums.Length; i++) {
        res = res ^ nums[i];
    }

    return res;
}

public string KnotHash(string line) {
    
    byte[] slengths = Encoding.ASCII.GetBytes(line);
    int[] lens = new int[slengths.Length];
    for(int i=0; i<slengths.Length; i++) lens[i] = (int)slengths[i];
    int[] tail = new int[] {17, 31, 73, 47, 23};
    int[] lengths = new int[lens.Length + tail.Length];
    lens.CopyTo(lengths, 0);
    tail.CopyTo(lengths, lens.Length);

    int[] list = RibbonHash(lengths);

    int[] dense = new int[256/16];
    int[] temp = new int[16];
    for(int i=0; i<256/16; i++) {
        for(int j=0; j<16; j++) temp[j] = list[(i*16)+j];
        dense[i] = XOR16(temp);
    }

    string hex = "";
    for(int i=0; i<dense.Length; i++) {
        hex += String.Format("{0:X}", dense[i]).ToLower();
    }

    return hex;
}


public int _1CountOn4(char r) {
    int count = 0;
    byte b;
    try{
        b = Convert.ToByte(r.ToString(), 16);
    } catch (FormatException e) {return 0;}

    for(int i=0; i<4; i++) {
        count += ( b & (1 << i)) > 0 ? 1 : 0;
    }
    
    return count;
}


StreamReader file = new StreamReader(@"input.txt");
string line;
if((line=file.ReadLine()) == null) {
    Console.WriteLine("Bad reading!");
    Environment.Exit(0);
}
file.Close();

int count = 0;
for(int i=0; i<128; i++) {
    string hiline = line+"-"+i;
    char[] res = KnotHash(hiline).ToCharArray();
    foreach(char c in res) count += _1CountOn4(c);
}


Console.WriteLine(count);
