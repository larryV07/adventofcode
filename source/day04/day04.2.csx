using System;
using System.IO;

public bool isAnagram(string s1, string s2) {
    char[] ch1 = s1.ToCharArray();
    char[] ch2 = s2.ToCharArray();

    Array.Sort(ch1);
    Array.Sort(ch2);

    if ((new String(ch1).Equals(new String(ch2)))) return true;
    return false;
}

StreamReader file = new StreamReader(@"C:\Users\Lorenzo Volpi\OneDrive - University of Pisa\adventofcode2017\day04\input.txt");

string line;
int count = 0;
while ((line=file.ReadLine()) != null) {
    string[] words = line.Split(' ');
    bool valid = true;
    for (int i=0; i<words.Length; i++) {
        string act = words[i];
        for(int j=0; j<i; j++) {
            if(isAnagram(act, words[j])) {
                valid = false;
                break; 
            }
        }
        if(!valid) break;
    }
    if (valid) count++;
}
Console.WriteLine(count);

file.Close();