using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public bool scanInTop(int iter, int height) {
    return iter % ((height-1)*2) == 0;
}

public int ScanRisk(int delay, ref int[] heights) {
    int risk = 0;
    
    for(int i=0; i<heights.Length; i++) {
        if(heights[i] > 0 && scanInTop(delay+i, heights[i])) risk += i*heights[i];
    }

    return risk;
}

public bool ZeroScanRisk(int delay, ref int[] heights) {
    bool zero = true;

    for(int i=0; i<heights.Length; i++) {
        if(heights[i] > 0 && scanInTop(delay+i, heights[i])) {
            zero = false;
            break;
        }
    }

    return zero;
}

public int MinDelay(ref int[] heights) {
    int delay = -1;
    while( !ZeroScanRisk(++delay, ref heights) );

    return delay;
}

int[] heights = new int[146];

StreamReader file = new StreamReader(@"input.txt");

string line;
while((line=file.ReadLine()) != null) {
    string[] split = line.Split(new string[] {": "}, StringSplitOptions.RemoveEmptyEntries);
    int ind = Int32.Parse(split[0]);
    heights[ind] = Int32.Parse(split[1]);
}

file.Close();

DateTime t1 = DateTime.Now;
int pt1 = ScanRisk(0, ref heights);
int pt2 = MinDelay(ref heights);
DateTime t2 = DateTime.Now;

Console.WriteLine("pt1: " + pt1);
Console.WriteLine("pt2: " + pt2);
Console.WriteLine("Time: " + (t2-t1).ToString("%mm'm '%s's '%fff'ms '"));