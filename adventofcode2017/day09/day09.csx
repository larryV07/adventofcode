using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public int[] RecursiveParse(char[] larr, int start, int level) {
    bool end = false;
    int nstart = start;
    int fres = level;
    int gcount = 0;
    
    while(!end && nstart < larr.Length){
        while(larr[nstart]!='{' && larr[nstart]!='<' && larr[nstart]!='}') {nstart++;}
        if (larr[nstart] == '{') {
            int[] res = RecursiveParse(larr, nstart+1, level+1);
            fres += res[0];
            nstart = res[1];
            gcount += res[2];
        }
        else if (larr[nstart] == '<') {
            int i;
            for(i=nstart+1; i<larr.Length; i++) {
                if(larr[i] == '!') i++;
                else {
                    if(larr[i] == '>') break;
                    else gcount++;
                } 
            }
            nstart = i+1;
        }
        else if (larr[nstart] == '}') {
            nstart++;
            end = true;
        }
    }

    return new int[] {fres, nstart, gcount};
}

StreamReader file = new StreamReader(@"C:\Users\Lorenzo Volpi\Documents\GitHub\adventofcode\adventofcode2017\day09\input.txt");

string line;
if((line=file.ReadLine()) == null) {
    Console.WriteLine("Bad reading!");
    Environment.Exit(0);
}

int[] res = RecursiveParse(line.ToCharArray(), 0, 0);

Console.WriteLine("Group deep level caount: " + res[0]);
Console.WriteLine("Non-canceled garbage count: " + res[2]);
