using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public void Bfs(int root, ref HashSet<int> adjs, Dictionary<int, List<int>> paths, ref int[] found) {
    List<int> lookup = new List<int>();
    lookup.Add(root);

    while(lookup.Count > 0) {
        int first = lookup[0];
        lookup.RemoveAt(0);
        List<int> adj = paths[first];
        foreach(int a in adj) {
            if( !adjs.Contains(a) ) {
                lookup.Add(a);
                adjs.Add(a);
                found[a] = 0;
            }
        }
    }


}

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

int[] found = new int[2000];
for(int i=0; i<2000; i++) found[i] = 1;
HashSet<int> adjs = new HashSet<int>();

Bfs(0, ref adjs, paths, ref found);
int pt1 = adjs.Count;

int i = 0, pt2 = 1;
while(i < 2000) {
    if(found[i] == 1) {
        adjs.Clear();
        Bfs(i, ref adjs, paths, ref found);
        pt2++;
    }
    i++;
}

Console.WriteLine(pt1);
Console.WriteLine(pt2);