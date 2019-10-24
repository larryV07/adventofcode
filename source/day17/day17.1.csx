using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;



StreamReader file = new StreamReader(@"input.txt");
string line;
if((line=file.ReadLine()) == null) {
    Console.WriteLine("Bad reading!");
    Environment.Exit(0);
}
file.Close();

int forw = Int32.Parse(line);
List<int> buffer = new List<int>();
buffer.Add(0);
int pos = 0;

for(int i=1; i<=2017; i++) {
    pos = ((pos + forw) % buffer.Count) + 1;
    buffer.Insert(pos, i);
}

Console.WriteLine(buffer[(pos+1)%buffer.Count]);
