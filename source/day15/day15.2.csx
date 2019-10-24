using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


// return true if first 16 bits af a and b are equals
public bool XOR16(UInt64 a, UInt64 b) {
    UInt64 _a = a & 65535, _b = b & 65535;
    return (_a ^ _b) == 0;
}

public UInt64 modgen(UInt64 prev, UInt64 inc, UInt64 mod, UInt64 _m) {
    UInt64 _p = prev;
    while(((_p = (_p * inc) % mod) & (_m-1)) != 0);
    return _p;
}

public UInt64 bitgen(UInt64 prev, UInt64 inc, UInt64 _m) {
    UInt64 _p = prev;
    while(true) {
        _p *= inc;
        while ((_p >> 31) != 0 )
            _p = (_p & 0x7fffffff) + (_p >> 31);
        
        if((_p & (_m-1)) == 0) break;
    }
    
    return _p;
}

StreamReader file = new StreamReader(@"input.txt");
string line;
if((line=file.ReadLine()) == null) {
    Console.WriteLine("Bad reading!");
    Environment.Exit(0);
}
file.Close();

string[] start = line.Split(';');
UInt64 preva = UInt64.Parse(start[0]), prevb = UInt64.Parse(start[1]);
UInt64 inca = 16807, incb = 48271;
UInt64 mod = 2147483647;

DateTime t1 = DateTime.Now;
int count = 0;
for(int i=0; i<5000000; i++) {
    preva = bitgen(preva, inca, 4);
    prevb = bitgen(prevb, incb, 8);

    if(XOR16(preva, prevb)) count++;
}
DateTime t2 = DateTime.Now;


Console.WriteLine(count);
Console.WriteLine("Time: " + (t2-t1).ToString("%mm'm '%s's '%fff'ms '"));
