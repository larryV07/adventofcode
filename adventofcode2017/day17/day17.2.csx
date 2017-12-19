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
int pos = 1, pos1 = 1;

for(int i=2, mod=2; i<=50000000; i++, mod++) {
    pos = ((pos + forw) % mod) + 1;
    if(pos == 1) pos1 = i;
}

Console.WriteLine(pos1);
