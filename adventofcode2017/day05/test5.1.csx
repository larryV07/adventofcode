using System;
using System.IO;
using System.Collections;

StreamReader file = new StreamReader(@"C:\Users\Lorenzo Volpi\OneDrive - University of Pisa\adventofcode2017\day05\input.txt");

int[] jumps;
List<int> jlist = new List<int>();
int i=0;
string line;
while((line=file.ReadLine()) != null) {
    jlist.Add(Int32.Parse(line));
    i++;
}
jumps = jlist.ToArray();
file.Close();

int count=0;
for(int i=0; i<jumps.Length; count++) {
    int act = jumps[i];
    jumps[i]++;
    i += act;
}

Console.WriteLine(count);