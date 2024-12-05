using System;
using System.IO;
using System.Text.RegularExpressions;
class Program{
    static string pattern1 = @"mul\(\d+,\d+\)";
    static string pattern2 = @"do\(\)|mul\(\d+,\d+\)|don't\(\)";
    static string numPattern = @"\d+";
    static string text = readText();
    static void Main(){
        solvePartOne();
        solvePartTwo();
    }

    static string readText(){
        if(File.Exists("../../../ref/puzzle.txt")){
            return File.ReadAllText("../../../ref/puzzle.txt");
        }
        return "Fail";
    }

 static void solvePartOne(){
         int total = 0;
        Regex rg = new Regex(pattern1);
        MatchCollection matches = rg.Matches(text);
        foreach(Match match in matches){
            Regex numRg = new Regex(numPattern);
            MatchCollection numMatches = numRg.Matches(match.Value);
            int first = Int32.Parse(numMatches[0].Value);
            int second = Int32.Parse(numMatches[1].Value); 
            total += first * second;
        }
        Console.WriteLine("Answer for part 1: " + total.ToString());
    }

    static void solvePartTwo(){
    int total = 0;
        bool canDo = true;
        Regex rg = new Regex(pattern2);
        MatchCollection matches = rg.Matches(text);

        foreach (Match match in matches){
            if (match.Value == "do()"){
                canDo = true;
            }
            else if (match.Value == "don't()"){
                canDo = false;
            }
            else if (canDo){
                Regex numRg = new Regex(numPattern);
                MatchCollection numMatches = numRg.Matches(match.Value);
                int first = Int32.Parse(numMatches[0].Value);
                int second = Int32.Parse(numMatches[1].Value); 
                total += first * second;
            }
        }
        Console.WriteLine("Answer for part 2: " + total.ToString());
    }
}