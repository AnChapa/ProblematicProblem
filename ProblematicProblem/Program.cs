using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            bool cont = false;
            string read = "";
            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

            while (cont != true) { 
                Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
                read = Console.ReadLine().ToLower();
                if (read == "no")
                    Environment.Exit(0);
                else if (read == "yes")
                    cont = true;
                else
                    Console.WriteLine("Sorry, I didn't catch that.");
                Console.WriteLine();
            }

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("What is your age? ");
            string input = Console.ReadLine();
            int userAge = 0;
            bool isValid = int.TryParse(input, out userAge);
            Console.WriteLine();

            cont = false;
            bool seeList = false;
            while (cont != true)
            {
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                read = Console.ReadLine().ToLower();
                if (read == "no thanks")
                    cont = true;
                else if (read == "sure")
                {
                    cont = true;
                    seeList = true;
                }
                else
                {
                    Console.WriteLine("Sorry, I didn't catch that.");
                    Console.WriteLine();
                }
            }

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();

                cont = false;
                bool addToList = false;
                while (cont != true)
                {
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                    read = Console.ReadLine().ToLower();
                    if (read == "no")
                        cont = true;
                    else if (read == "yes")
                    {
                        cont = true;
                        addToList = true;
                    }
                    else
                        Console.WriteLine("Sorry, I didn't catch that.");
                    Console.WriteLine();
                }

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();

                    cont = false;
                    while (cont != true) 
                    {
                        Console.WriteLine("Would you like to add more? yes/no: ");
                        read = Console.ReadLine().ToLower();
                        if(read == "no")
                        {
                            cont = true;
                            addToList = false;
                        }
                        else if(read == "yes")
                        {
                            cont = true;
                        }
                        else
                            Console.WriteLine("Sorry, I didn't catch that.");

                        Console.WriteLine();
                    }
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();

                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                cont = false;
                while (cont != true)
                {
                    Console.Write($"Ah got it! {randomActivity}, your random activity is: {userName}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    read = Console.ReadLine().ToLower();
                    if (read == "redo")
                    {
                        cont = true;
                    }
                    else if (read == "keep")
                        Environment.Exit(0);
                    else {
                        Console.WriteLine("Sorry, I didn't catch that.");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}