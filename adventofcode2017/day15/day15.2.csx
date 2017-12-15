using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


// return true if first 16 bits af a and b are equals
public bool XOR16(long a, long b) {
    long _a = a % 65536, _b = b % 65536;
    // Console.WriteLine(_a+";"+_b);
    return (_a ^ _b) == 0;
}


StreamReader file = new StreamReader(@"input.txt");
string line;
if((line=file.ReadLine()) == null) {
    Console.WriteLine("Bad reading!");
    Environment.Exit(0);
}
file.Close();

string[] start = line.Split(';');
long preva = Int32.Parse(start[0]), prevb = Int32.Parse(start[1]);
int inca = 16807, incb = 48271;
int mod = 2147483647;

int count = 0;
for(int i=0; i<5000000; i++) {
    while((preva = (preva * inca) % mod) % 4 != 0);
    while((prevb = (prevb * incb) % mod) % 8 != 0);

    if(XOR16(preva, prevb)) count++;
}

Console.WriteLine(count);