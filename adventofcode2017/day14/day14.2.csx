using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public void Bfs(int[] root, ref int val, ref int[,] matrix) {
    List<int[]> lookup = new List<int[]>();
    lookup.Add(root);

    val++;
    matrix[root[0], root[1]] = val;

    while(lookup.Count > 0) {
        int[] first = lookup[0];
        lookup.RemoveAt(0);
        
        if(first[0] > 0 && matrix[first[0]-1, first[1]] == -1) {
            lookup.Add(new int[] {first[0]-1, first[1]});
            matrix[first[0]-1, first[1]] = val;
        }
        if(first[0] < 127 && matrix[first[0]+1, first[1]] == -1) {
            lookup.Add(new int[] {first[0]+1, first[1]});
            matrix[first[0]+1, first[1]] = val;
        }
        if(first[1] > 0 && matrix[first[0], first[1]-1] == -1) {
            lookup.Add(new int[] {first[0], first[1]-1});
            matrix[first[0], first[1]-1] = val;
        }
        if(first[1] < 127 && matrix[first[0], first[1]+1] == -1) {
            lookup.Add(new int[] {first[0], first[1]+1});
            matrix[first[0], first[1]+1] = val;
        }

    }

}

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
        hex += String.Format("{0:X2}", dense[i]).ToLower();
    }

    return hex;
}


public void _1setOn4(int line, int start, ref int[,] matrix, char r) {
    byte b;
    try{
        b = Convert.ToByte(r.ToString(), 16);
    } catch (FormatException e) {return;}

    for(int i=0; i<4; i++) {
        matrix[line, start+i] = ( b & (8 >> i)) > 0 ? -1 : 0;
    }
}


StreamReader file = new StreamReader(@"input.txt");
string line;
if((line=file.ReadLine()) == null) {
    Console.WriteLine("Bad reading!");
    Environment.Exit(0);
}
file.Close();

int[,] matrix = new int[128, 128];
for(int i=0; i<128; i++) {
    string hiline = line+"-"+i;
    char[] res = KnotHash(hiline).ToCharArray();
    for(int j=0; j<128/4; j++) {
        _1setOn4(i, j*4, ref matrix, res[j]);
    }
}

int count = 0;
for(int i=0; i<128; i++) {
    for(int j=0; j<128; j++) {
        if(matrix[i, j] == -1) Bfs(new int[] {i, j}, ref count, ref matrix);
    }
}

Console.WriteLine(count);

