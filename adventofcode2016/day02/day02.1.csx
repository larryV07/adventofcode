using System;
using System.IO;


public void UpdatePos(ref int[] pos, char dir) {

    if(dir=='U') { if(pos[1]<1) pos[1]++; }
    else if(dir=='D') { if(pos[1]>-1) pos[1]--; }
    else if(dir=='R') { if(pos[0]<1) pos[0]++; }
    else if(dir=='L') { if(pos[0]>-1) pos[0]--; }

}

public int PadNum(int[] pos) {

    if(pos[0]==-1 && pos[1]==1) return 1;
    else if(pos[0]==0 && pos[1]==1) return 2;
    else if(pos[0]==1 && pos[1]==1) return 3;
    else if(pos[0]==-1 && pos[1]==0) return 4;
    else if(pos[0]==0 && pos[1]==0) return 5;
    else if(pos[0]==1 && pos[1]==0) return 6;
    else if(pos[0]==-1 && pos[1]==-1) return 7;
    else if(pos[0]==0 && pos[1]==-1) return 8;
    else if(pos[0]==1 && pos[1]==-1) return 9;
    else return 0;

}


StreamReader file = new StreamReader("input.txt");

List<string> lines = new List<string>();
string l;
while((l=file.ReadLine()) != null) {
    lines.Add(l);
}

file.Close();

int[] pos = new int[] {0, 0};
char[] dirs;
List<int> pad = new List<int>();
foreach(string l in lines) {
    dirs = l.ToCharArray();
    foreach(char c in dirs) {
        UpdatePos(ref pos, c);
    }
    pad.Add(PadNum(pos));
}

foreach(int n in pad) Console.Write(n);
Console.WriteLine();

