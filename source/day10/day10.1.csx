using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

StreamReader file = new StreamReader(@"C:\Users\Lorenzo Volpi\Documents\GitHub\adventofcode\adventofcode2017\day10\input.txt");

string line;
if((line=file.ReadLine()) == null) {
    Console.WriteLine("Bad reading!");
    Environment.Exit(0);
}

file.Close();

string[] slengths = line.Split(new char[]{','});
int[] lengths = new int[slengths.Length];
for(int i=0; i<slengths.Length; i++){
    try{
        lengths[i] = Int32.Parse(slengths[i]);    
    } catch (FormatException e) {
        Console.WriteLine("Format: " + slengths[i]);
    }
    // Console.WriteLine(lengths[i]);
} 

int[] list = new int[256];
for(int i = 0; i<list.Length; i++) list[i] = i;
int skip = 0;
int pos = 0;

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

Console.WriteLine(list[0] * list[1]);
