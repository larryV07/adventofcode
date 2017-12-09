using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public int[] RecursiveParse(char[] larr, int start, int level) {
    if (larr[start] == '{') {
        bool end = false;
        int nstart = start+1;
        int fres = level;
        while(!end) {
            int[] res = RecursiveParse(larr, nstart, level+1);
            if (res[0] >= 0) {
                fres += res[0];
                nstart = res[1];
            } else {
                end = true;
                nstart = res[1];
            }
        }
        return new int[] {fres, nstart};
    }
    else if (larr[start] == '<') {
        int i;
        for(i=start+1; i<larr.Length; i++) {
            if(larr[i] == '!') i++;
            else if(larr[i] == '>') break; 
        }
        if (larr[i+1] == ',') return new int[] {0, i+2};
        else return new int[] {0, i+i};
    }
    else if (larr[start] == '}') {
        if (start+1 < larr.Length && larr[start+1] == ',') return new int[] {-1, start+2};
        else return new int[] {-1, start+1};
    } else return new int[] {-1, -1};
}

StreamReader file = new StreamReader(@"C:\Users\Lorenzo Volpi\Documents\GitHub\adventofcode\adventofcode2017\day09\input.txt");

string line;
if((line=file.ReadLine()) == null) {
    Console.WriteLine("Bad reading!");
    Environment.Exit(0);
}

int[] res = RecursiveParse(line.ToCharArray(), 0, 1);

Console.WriteLine(res[0]);
