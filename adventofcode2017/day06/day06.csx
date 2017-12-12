using System;
using System.IO;
using System.Collections;


public bool compareBanks(int[] b1, int[] b2) {
    if(b1.Length != b2.Length) return false;

    for(int i=0; i<b1.Length; i++) {
        if(b1[i] != b2[i]) return false;
    }

    return true;
}

public int[] reallocateBank(int[] bank) {
    int[] result = new int[bank.Length];

    int maxval=-1, maxind=-1;
    for(int i=0; i<bank.Length; i++) {
        if(bank[i]>maxval) {
            maxval = bank[i];
            maxind = i;
        }
        result[i] = bank[i];
    }

    result[maxind] = 0;
    for(int i=(maxind+1)%bank.Length; maxval>0; maxval--, i=(i+1)%bank.Length) {
        result[i]++;
    }

    return result;
}

StreamReader file = new StreamReader(@"C:\Users\Lorenzo Volpi\OneDrive - University of Pisa\adventofcode2017\day06\input.txt");

List<int[]> jlist = new List<int[]>();
int[] bank;
string line;
if((line=file.ReadLine()) != null) {
    string[] blocks = line.Split('\t');
    bank = new int[blocks.Length];
    for(int i=0; i<blocks.Length; i++) {
        bank[i] = Int32.Parse(blocks[i]);
    }
    jlist.Add(bank);
}


bool cycle = false;
int cyclesize = 0;
int count = 0;
while(!cycle){
    count++;
    int[] newb = reallocateBank(jlist.Last());
    for(int i=0; i<jlist.Count; i++) {
        if(compareBanks(newb, jlist[i])) {
            cycle = true;
            cyclesize = jlist.Count - i;
            break;
        }
    }
    jlist.Add(newb);
}

Console.WriteLine("Iterations: " + count);
Console.WriteLine("cycle size: " + cyclesize);
