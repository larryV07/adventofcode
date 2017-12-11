using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public void UpdateTrip(string step, ref int x, ref int y) {
    
    if(step == "n") { y+=2; }
    else if(step == "s") { y+=-2; }
    else if(step == "ne") { x+=1; y+=1; }
    else if(step == "nw") { x+=-1; y+=1; }
    else if(step == "se") { x+=1; y+=-1; }
    else if(step == "sw") { x+=-1; y+=-1; }
    
}

// Extended form
public int HexDistanceExtended(int x, int y) {
    int line = 0, diag = 0; 
    if(Math.Abs(y) > Math.Abs(x)) {
        line = (Math.Abs(y) - Math.Abs(x))/2;
        diag = Math.Abs(x);
    } else if(Math.Abs(y) < Math.Abs(x)) {
        line = Math.Abs(x) - Math.Abs(y);
        diag = Math.Abs(y);
    } else {
        diag = Math.Abs(x);
    }

    return diag + line;
}

// Condensed form
public int HexDistanceCondensed(int x, int y) {
    int _x=Math.Abs(x), _y=Math.Abs(y);
    return _y > _x ? ((_y + _x)/2) : _x;
}

StreamReader file = new StreamReader("input.txt");

string line;
if((line=file.ReadLine()) == null) {
    Console.WriteLine("Bad reading!");
    Environment.Exit(0);
}

file.Close();

string[] steps = line.Split(new char[]{','});
int x = 0, y = 0, max = 0;
for(int i=0; i<steps.Length; i++){
    UpdateTrip(steps[i], ref x, ref y);
    int temp = HexDistanceCondensed(x, y);
    if(temp > max) max = temp;
} 

Console.WriteLine("pt1: " + HexDistanceCondensed(x, y));
Console.WriteLine("pt2: " + max);
