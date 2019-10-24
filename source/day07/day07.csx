using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Node {

    private string value= "";
    private int weight = -1;
    private Node parent;
    private List<string> children;

    private static Dictionary<string, Node> nodeMap;

    private Node(string value, int weight, List<string> children) {
        this.value = value;
        this.weight = weight;
        this.parent = null;
        this.children = children;
    }

    public Node(Node parent) {
        this.parent = parent;
    }

    static Node() {
        nodeMap = new Dictionary<string, Node>();
    }



    public static void CreateNode(string value, int weight, List<string> children) {
        Node nn;
        try{
            nn = nodeMap[value];
            nn.value = value;
            nn.weight = weight;
            nn.children = children; 
        } catch (KeyNotFoundException e) {
            nn = new Node(value, weight, children);
            try{
                nodeMap[value]=nn;
            } catch (ArgumentException e1) {Console.WriteLine("ops"); }    
        }
      
        if (children != null) {
            foreach(string c in children) {
                if (nodeMap.ContainsKey(c)) {
                    nodeMap[c].Parent = nn;
                } else {
                    nodeMap[c] = new Node(nn);
                }
            }
        }

    }

    public static string GetRoot() {
        string res = null;

        foreach(KeyValuePair<string, Node> entry in nodeMap) {
            if (entry.Value.Parent == null) {
                res = entry.Key;
                break;
            }
        }

        return res;
    }

    public static int GetBalance(string root) {

        Node n = nodeMap[root];
        if (n.children != null) {
            int balance = -1;
            foreach(string c in n.children) {
                int val = GetBalance(c);
                if (val < 0) return val;
                else {
                    if (balance == -1) balance = val; 
                    else {
                        if (val != balance) {
                            int diff = Math.Abs(val-balance);
                            return -(nodeMap[c].weight - diff);
                        }
                    }
                }
            }

            return n.weight + n.children.Count*balance;
        } else return n.weight;

    }

    public Node Parent{
        get{ return this.parent; }
        set{ this.parent = value; }
    }

    public static int MapCount {
        get{ return nodeMap.Count; }
    }

}


public void parseLine(string line) {

    string[] split = line.Split(new string[] {" (", ") -> ", ", ", ")"}, StringSplitOptions.RemoveEmptyEntries);
    string value = split[0];
    int weight = Int32.Parse(split[1]);
    List<string> children = null;
    if(split.Length > 2) {
        children = new List<string>();
        for(int i=2; i<split.Length; i++) {
            children.Add(split[i]);
        }
    }

    Node.CreateNode(value, weight, children);
}

StreamReader file = new StreamReader(@"C:\Users\Lorenzo Volpi\OneDrive - University of Pisa\adventofcode2017\day07\input.txt");

string line;
while((line=file.ReadLine()) != null) {
    parseLine(line);
}

Console.WriteLine(Node.MapCount);
Console.WriteLine(Node.GetRoot());
Console.WriteLine(Node.GetBalance(Node.GetRoot()));


