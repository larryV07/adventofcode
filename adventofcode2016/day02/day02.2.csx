using System;
using System.IO;


public void UpdatePos(ref int[] pos, char dir) {

    if(dir=='U') { 
        if( (pos[1]<2 && pos[0] == 0) ||
            (pos[1]<1 && (pos[0]==1 || pos[0]==-1))
        ) pos[1]++; 
    }
    else if(dir=='D') { 
        if( (pos[1]>-2 && pos[0] == 0) ||
            (pos[1]>-1 && (pos[0]==1 || pos[0]==-1))
        ) pos[1]--; 
    }
    else if(dir=='R') { 
        if( (pos[0]<2 && pos[1] == 0) ||
            (pos[0]<1 && (pos[1]==1 || pos[1]==-1))
        ) pos[0]++; 
    }
    else if(dir=='L') { 
        if( (pos[0]>-2 && pos[1] == 0) ||
            (pos[0]>-1 && (pos[1]==1 || pos[1]==-1))
        ) pos[0]--; 
    }

}

public char PadNum(int[] pos) {
    
    if(pos[0]==0 && pos[1]==2) return '1';
    else if(pos[0]==-1 && pos[1]==1) return '2';
    else if(pos[0]==0 && pos[1]==1) return '3';
    else if(pos[0]==1 && pos[1]==1) return '4';
    else if(pos[0]==-2 && pos[1]==0) return '5';
    else if(pos[0]==-1 && pos[1]==0) return '6';
    else if(pos[0]==0 && pos[1]==0) return '7';
    else if(pos[0]==1 && pos[1]==0) return '8';
    else if(pos[0]==2 && pos[1]==0) return '9';
    else if(pos[0]==-1 && pos[1]==-1) return 'A';
    else if(pos[0]==0 && pos[1]==-1) return 'B';
    else if(pos[0]==1 && pos[1]==-1) return 'C';
    else if(pos[0]==0 && pos[1]==-2) return 'D';
    else return '0';

}


StreamReader file = new StreamReader("input.txt");

List<string> lines = new List<string>();
string l;
while((l=file.ReadLine()) != null) {
    lines.Add(l);
}

file.Close();

int[] pos = new int[] {-2, 0};
char[] dirs;
List<char> pad = new List<char>();
foreach(string l in lines) {
    dirs = l.ToCharArray();
    foreach(char c in dirs) {
        UpdatePos(ref pos, c);
    }
    pad.Add(PadNum(pos));
}

foreach(char n in pad) Console.Write(n);
Console.WriteLine();

