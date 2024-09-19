using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input your grade:");
        int grade = int.Parse(Console.ReadLine());
        string lgrade;
        if(grade >= 90) lgrade = "A";
        else if(grade >= 80) lgrade = "B";
        else if(grade >= 70) lgrade = "C";
        else if(grade >= 60) lgrade = "D";
        else lgrade = "F"; 
        Console.WriteLine($"Your grade is a/an {lgrade}");
    }
}