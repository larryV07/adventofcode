using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public void Spin(int s, ref string[] arr) {
    int _s = s % arr.Length;
    string[] _t = new string[arr.Length];
    for(int i = 0; i<arr.Length; i++) {
        _t[(i+_s)%arr.Length] = arr[i];
    }
    for(int i=0; i<arr.Length; i++) arr[i] = _t[i];
}

public void Exchange(int i, int j, ref string[] arr) {
    string _t = arr[i];
    arr[i] = arr[j];
    arr[j] = _t;
}

public void parseComm(string comm, ref string[] arr) {

    if(comm.StartsWith("s")) {
        int s = Int32.Parse(comm.Substring(1));
        Spin(s, ref arr);
    } else if(comm.StartsWith("x")) {
        string[] args = comm.Substring(1).Split('/');
        Exchange(Int32.Parse(args[0]), Int32.Parse(args[1]), ref arr);
    } else if(comm.StartsWith("p")) {
        string[] args = comm.Substring(1).Split('/');
        int a=-1, b=-1, i=-1;
        while(++i<16 && a == -1) if(arr[i].Equals(args[0])) a = i;        
        i=-1;
        while(++i<16 && b == -1) if(arr[i].Equals(args[1])) b = i;
        Exchange(a, b, ref arr);        
    }


}


public bool arreq(string[] a, string[] b) {
    for(int i=0; i<a.Length; i++) {
        if(!a[i].Equals(b[i])) return false;
    }

    return true;
}


StreamReader file = new StreamReader(@"input.txt");
string line;
if((line=file.ReadLine()) == null) {
    Console.WriteLine("Bad reading!");
    Environment.Exit(0);
}
file.Close();

string[] comms = line.Split(',');
string[] arr = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p"};
string[] orig = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p"};

int count = 0;
bool end = false;
while(!end){
    foreach(string c in comms) {
        count++;
        parseComm(c, ref arr);
        if(arreq(arr, orig)) {
            end=true;
            break;
        }
    }
}

if( (count % comms.Length) == 0 ) {
    int iter = 1000000000 % (count/comms.Length);

    for(int i=0; i<iter; i++) {
        foreach(string c in comms) {
            parseComm(c, ref arr);
        }
    }

    foreach(string s in arr) Console.Write(s);
    Console.WriteLine();
}