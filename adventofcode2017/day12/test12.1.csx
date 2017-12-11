using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public void UpdateTrip(string step, ref double x, ref double y) {
    
    if(step == "n") { y+=1; }
    else if(step == "s") { y+=-1; }
    else if(step == "ne") { x+=0.5; y+=0.5; }
    else if(step == "nw") { x+=-0.5; y+=0.5; }
    else if(step == "se") { x+=0.5; y+=-0.5; }
    else if(step == "sw") { x+=-0.5; y+=-0.5; }
    
}

public double HexDistance(double x, double y) {
    double line = 0, diag = 0; 
    if(Math.Abs(y) > Math.Abs(x)) {
        line = Math.Abs(y) - Math.Abs(x);
        diag = Math.Abs(x * 2.0);
    } else if(Math.Abs(y) < Math.Abs(x)) {
        line = (Math.Abs(x) - Math.Abs(y))*2;
        diag = Math.Abs(y * 2.0);
    } else {
        diag = Math.Abs(x * 2.0);
    }


    return diag + line;
}


StreamReader file = new StreamReader(@"input.txt");

string line;
if((line=file.ReadLine()) == null) {
    Console.WriteLine("Bad reading!");
    Environment.Exit(0);
}

file.Close();

string[] steps = line.Split(new char[]{','});
double x = 0, y = 0, max = 0;
for(int i=0; i<steps.Length; i++){
    UpdateTrip(steps[i], ref x, ref y);
    double temp = HexDistance(x, y);
    max = temp > max ? temp : max;
} 

Console.WriteLine(x+";"+y);
Console.WriteLine(HexDistance(x, y));
Console.WriteLine(max);
