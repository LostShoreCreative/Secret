using System;

class Program
{
    enum State
    {
        Menu,
        Load,
        Add,
        Test,
        Quit
    }

    static bool isRunning = true;
    static State state = State.Menu;
    static void Main(string[] args)
    {
        while(isRunning)
        {
            Console.Clear();
            switch(state)
            {
                case State.Menu:
                HandleMenu();
                break;
                case State.Load:
                HandleLoad();
                break;
                case State.Add:
                HandleNew();
                break;
                case State.Test:
                HandleTest();
                break;
                case State.Quit:
                isRunning = false;
                break;
            }
        }
    }

    static void HandleMenu()
    {
        Console.WriteLine("1. New Scripture\n2. Choose Scripture\n3. Quit(q)");
        switch(Console.ReadLine().ToUpper())
        {
            case "1":
            case "NEW":
            state = State.Add;
            break;
            case "2":
            case "LOAD":
            state = State.Load;
            break;
            case "3":
            case "Q":
            break;
        }
    }

    static void HandleNew()
    {
        string reference;
        string text;
        Console.WriteLine("Add the reference:");
        reference = Console.ReadLine();
        Console.WriteLine("Add the text");
        text = Console.ReadLine();
        Tester.MakeScripture(reference, text);
        state = State.Menu;
    }
    static void HandleLoad()
    {
        Scripture[] scriptures = Tester.GetScriptures().ToArray();
        for(int i = 0; i < scriptures.Length; i++)
        {
            Console.WriteLine($"{i+1}. {scriptures[i].reference}");
        }
        Console.WriteLine("Type the number of the scripture you want");
        int index = int.Parse(Console.ReadLine())-1;
        Tester.SelectScripture(index);
        state = State.Test;   
    }

    static void HandleTest()
    {
        Console.WriteLine(Tester.GetScripture());
        Console.WriteLine("Type r to remove a word\nq to quit\n b to return");
        switch(Console.ReadLine().ToUpper())
        {
            case "R":
            Tester.RemoveWord();
            break;
            case "Q":
            isRunning = false;
            break;
            case "B":
            state = State.Menu;
            break;
        }
    }
}