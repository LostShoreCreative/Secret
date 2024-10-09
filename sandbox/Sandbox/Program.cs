using System;
class Program
{
  static void Main(string[] args)
    {
        bool isRunning = true;
        while(isRunning){
            Console.Clear();
            Console.WriteLine("1. New Journal Entry\n2. Load Journal Entry\nType 1, New, 2, Load, or Exit");
            switch(Console.ReadLine().ToUpper())
            {
                case "1":
                case "NEW":
                Console.WriteLine("Type your entry here");
                Journal.MakeEntry(Console.ReadLine());
                Journal.Save();
                break;
                case "2":
                case "LOAD":
                List<Entry> entries = Journal.GetEntries();
                int count = 1;
                foreach(Entry entry in entries)
                {
                    Console.WriteLine($"{count}. {entry.GetDate()}");
                    count++;
                }
                Console.WriteLine("Type the number for the entry you want to read");
                Console.WriteLine(Journal.GetEntry(int.Parse(Console.ReadLine())-1) + "\nPress enter when done");
                Console.ReadLine();

                break;
                case "EXIT":
                isRunning = false;
                break;
            }
        }
    }
}