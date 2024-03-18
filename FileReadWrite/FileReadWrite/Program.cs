using System;
using System.IO;
string file = "file.txt";

if (!File.Exists(file))
{
    using (FileStream fs = File.Create(file))
    {
        Console.WriteLine("File created!");
    }
}

do
{
    Console.WriteLine("Enter data to add to file:");
    string inputData = Console.ReadLine();

    using (StreamWriter writer = new StreamWriter(file, true))
    {
        writer.WriteLine(inputData);
    }

    Console.WriteLine("Do you want to add more data (y/n):");
    string choice = Console.ReadLine().ToLower();

    if (choice == "y" || choice == "yes")
    {
        Console.WriteLine("Do you want to see data (y/n):");
        string ch = Console.ReadLine().ToLower();
        if(ch == "y" || ch == "yes")
        {
            DisplayData();
        }
    }

    if (choice == "n" || choice == "no")
    {
        DisplayData();
        break;
    }
}
while (true);

void DisplayData()
{
    if (File.Exists(file))
    {
        Console.WriteLine();
        string[] lines = File.ReadAllLines(file);
        foreach (string ln in lines)
            Console.WriteLine(ln);
        Console.WriteLine();
    }
}