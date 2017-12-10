using System;
using System.IO;
using System.Collections;

public string[] ParseLine(string line) {
    return line.Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
}


StreamReader file = new StreamReader(@"C:\Users\Lorenzo Volpi\Documents\GitHub\adventofcode\adventofcode2016\day01\input.txt");

string line;
if((line=file.ReadLine()) == null) {
    Environment.Exit(1);
}

string[] split = ParseLine(line);
int x=0, y=0;
int axis = -1, sign = +1;
<<<<<<< HEAD:adventofcode2016/day01/day01.csx
=======
Dictionary<string, int> locations = new Dictionary<string, int>();
locations.Add("0;0", 1);
bool found = false;
>>>>>>> edit-day01-pt2-2016:adventofcode2016/day01/day01.2.csx
foreach(string c in split) {
    char dir = c.First();
    int pad = Int32.Parse(c.Remove(0, 1));
    
    if(dir == 'R') sign *= -axis; 
    if(dir == 'L') sign *= axis;
    axis *= -1;

<<<<<<< HEAD:adventofcode2016/day01/day01.csx
    if (axis > 0) x += pad * sign;
    if (axis < 0) y += pad * sign;

=======
    if (axis > 0) {
        int i;
        for(i = 1; i<=pad; i++) {
            x+=sign;
            string arr = x+";"+y;
            if(locations.ContainsKey(arr)) {
                found = true;
                break;
            } else {
                locations[arr] = 1;
            }
        }
    }
    if (axis < 0) {
        int i;
        for(i = 1; i<=pad; i++) {
            y+=sign;
            string arr = x+";"+y;
            if(locations.ContainsKey(arr)) {
                found = true;
                break;
            } else {
                locations[arr] = 1;
            }
        }
    }
    
    if (found) break;
>>>>>>> edit-day01-pt2-2016:adventofcode2016/day01/day01.2.csx
}

Console.WriteLine(Math.Abs(x) + Math.Abs(y));
Console.WriteLine(x+";"+y);