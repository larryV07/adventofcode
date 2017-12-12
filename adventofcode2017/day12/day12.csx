using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public void 

Dictionary<int, List<int>> paths = new Dictionary<int, List<int>>();

StreamReader file = new StreamReader(@"input.txt");

string line;
while((line=file.ReadLine()) != null) {
    string[] split = line.Split(new string[] {" <-> ", ", "}, StringSplitOptions.RemoveEmptyEntries);
    int head = Int32.Parse(split[0]);
    List<int> adj = new List<int>();
    for(int i=1; i<split.Length; i++) 
        adj.Add(Int32.Parse(split[i]));
    
    paths[head] = adj;
}

file.Close();


