using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


StreamReader file = new StreamReader(@"C:\Users\Lorenzo Volpi\Documents\GitHub\adventofcode\adventofcode2017\day09\input.txt");

string line;
if((line=file.ReadLine()) == null) {
    Console.WriteLine("Bad reading!");
    Environment.Exit(0);
}

Console.WriteLine(line);
