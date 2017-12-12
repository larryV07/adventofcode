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
string l1, l2, l3;
while((l1=file.ReadLine()) != null && (l2=file.ReadLine()) != null && (l3=file.ReadLine()) != null) {
    string[] sn1 = l1.Split(new string[] {"  "}, StringSplitOptions.RemoveEmptyEntries);
    string[] sn2 = l2.Split(new string[] {"  "}, StringSplitOptions.RemoveEmptyEntries);
    string[] sn3 = l3.Split(new string[] {"  "}, StringSplitOptions.RemoveEmptyEntries);
    
    for(int j=0; j<3; j++) {
        int[] n = new int[3];
        n[0] = Int32.Parse(sn1[j]); 
        n[1] = Int32.Parse(sn2[j]); 
        n[2] = Int32.Parse(sn3[j]); 
        triangles.Add(n);
    }
    
}

file.Close();

int count = 0;
foreach(int[] tri in triangles) {
    if(CheckTriangle(tri)) count++;
}

Console.WriteLine(count);



