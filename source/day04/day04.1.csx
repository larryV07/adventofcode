using System;
using System.IO;

StreamReader file = new StreamReader(@"C:\Users\Lorenzo Volpi\OneDrive - University of Pisa\adventofcode2017\day04\input.txt");

string line;
int count = 0, lines=0;
while ((line=file.ReadLine()) != null) {
    lines++;
    string[] words = line.Split(' ');
    bool valid = true;
    for (int i=0; i<words.Length; i++) {
        string act = words[i];
        for(int j=0; j<i; j++) {
            if(act.Equals(words[j])) {
                valid = false;
                break; 
            }
        }
        if(!valid) break;
    }
    if (valid) count++;
}
Console.WriteLine(count);
Console.WriteLine(lines);

file.Close();