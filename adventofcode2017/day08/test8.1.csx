using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Instruction {

    private string var;
    private string op;
    private int value;
    private string var_cond;
    private string op_cond;
    private int value_cond;

    private static int maxMapValueEver;

    private static Dictionary<string, int> varMap;

    private Instruction(string var, string op, int value, string var_cond, string op_cond, int value_cond) {
        this.var = var;
        this.op = op;
        this.value = value;
        this.var_cond = var_cond;
        this.op_cond = op_cond;
        this.value_cond = value_cond;
    }

    public bool CheckCond() {
        int cv;
        try{
            cv = varMap[this.var_cond];
        } catch(KeyNotFoundException e) {
            cv = 0;
            varMap[this.var_cond] = 0;
            if (cv > maxMapValueEver) maxMapValueEver = cv;
        }

        if (this.op_cond.Equals("==")) return (varMap[this.var_cond] == this.value_cond);
        else if (this.op_cond.Equals("!=")) return (varMap[this.var_cond] != this.value_cond);
        else if (this.op_cond.Equals("<=")) return (varMap[this.var_cond] <= this.value_cond);
        else if (this.op_cond.Equals(">=")) return (varMap[this.var_cond] >= this.value_cond);
        else if (this.op_cond.Equals(">")) return (varMap[this.var_cond] > this.value_cond);
        else if (this.op_cond.Equals("<")) return (varMap[this.var_cond] < this.value_cond);
        else return false;
    }

    public void ExecuteOp() {
        int ov;
        try{
            ov = varMap[this.var];
        } catch(KeyNotFoundException e) {
            ov = 0;
            varMap[this.var] = 0;
            if (ov > maxMapValueEver) maxMapValueEver = ov;
        }

        if(this.op == "inc") {
            varMap[this.var] += this.value;
        } else if (this.op == "dec") {
            varMap[this.var] -= this.value;
        }
        if (varMap[this.var] > maxMapValueEver) maxMapValueEver = varMap[this.var];

    }



    static Instruction() {
        varMap = new Dictionary<string, int>();
        maxMapValueEver = Int32.MinValue;
    }
   

    public static Instruction ParseLine(string line) {
        string[] split = line.Split(new string[] {" if ", " "}, StringSplitOptions.RemoveEmptyEntries);
        int value = Int32.Parse(split[2]);
        int value_cond = Int32.Parse(split[5]);
        return new Instruction(split[0], split[1], value, split[3], split[4], value_cond);
    }

    public static void PrintMap() {
        foreach(KeyValuePair<string, int> entry in varMap) {
            Console.WriteLine(entry.Key+": "+entry.Value);
        }
    }

    public static int MaxMapValue() {
        int max = Int32.MinValue;
        foreach(KeyValuePair<string, int> entry in varMap) {    
            if (entry.Value > max) max = entry.Value;
        }

        return max;
    }

    public static int MaxMapValueEver{
        get{ return maxMapValueEver;}
    }
    
    
}




StreamReader file = new StreamReader(@"C:\Users\Lorenzo Volpi\OneDrive - University of Pisa\adventofcode2017\day08\input.txt");

string line;
while((line=file.ReadLine()) != null) {
    Instruction inst = Instruction.ParseLine(line);
    if (inst.CheckCond()) inst.ExecuteOp();
}

Console.WriteLine(Instruction.MaxMapValue());
Console.WriteLine(Instruction.MaxMapValueEver);

