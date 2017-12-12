using System;
using System.IO;


public bool CheckTriangle(int[] tri) {
    bool res = true;
    for(int i=0; i<3; i++) {
        if(tri[(i+1)%3]+tri[(i+2)%3] <= tri[i]) res = false;  
    }

    return res;
}


StreamReader file = new StreamReader("input.txt");

List<int[]> triangles = new List<int[]>();
string l;
while((l=file.ReadLine()) != null) {
    string[] sn = l.Split(new string[] {"  "}, StringSplitOptions.RemoveEmptyEntries);
    int[] n = new int[sn.Length];
    for(int i=0; i<sn.Length; i++) { n[i] = Int32.Parse(sn[i]); }
    triangles.Add(n);
}

file.Close();

int count = 0;
foreach(int[] tri in triangles) {
    if(CheckTriangle(tri)) count++;
}

Console.WriteLine(count);



