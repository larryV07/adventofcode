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
            Console.WriteLine(start + ";" + end);
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

StreamReader file = new StreamReader(@"C:\Users\Lorenzo Volpi\Documents\GitHub\adventofcode\adventofcode2017\day10\input.txt");

string line;
if((line=file.ReadLine()) == null) {
    Console.WriteLine("Bad reading!");
    Environment.Exit(0);
}

file.Close();

byte[] slengths = Encoding.ASCII.GetBytes(line);
int[] lens = new int[slengths.Length];
for(int i=0; i<slengths.Length; i++){
    lens[i] = (int)slengths[i];    
    Console.WriteLine(lens[i]);
}
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

string[] hex = new string[256/16];
for(int i =0; i<dense.Length; i++) {
    Console.Write(String.Format("{0:X}", dense[i]).ToLower());
}
Console.WriteLine();

