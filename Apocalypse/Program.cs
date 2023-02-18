using System;
using System.Collections.Generic;
using System.Linq;

namespace StackAndQueueProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            List<Medicaments> medicamentsList = new List<Medicaments>();
            medicamentsList.Add(new Medicaments("Patch"));
            medicamentsList.Add(new Medicaments("Bandage"));
            medicamentsList.Add(new Medicaments("MedKit"));
            while (textiles.Count > 0 && medicaments.Count > 0)
            {
                int value = textiles.Peek() + medicaments.Peek();

                if (value == 30)
                {
                    medicamentsList[0].Count++;
                    textiles.Dequeue();
                    medicaments.Pop();
                }
                else if (value == 40)
                {
                    medicamentsList[1].Count++;
                    textiles.Dequeue();
                    medicaments.Pop();
                }
                else if (value == 100)
                {
                    medicamentsList[2].Count++;
                    textiles.Dequeue();
                    medicaments.Pop();
                }
                else
                {
                    if (value > 100)
                    {
                        medicamentsList[2].Count++;
                        textiles.Dequeue();
                        int element = value - 100;
                        medicaments.Pop();
                        element = element + medicaments.Peek();
                        medicaments.Pop();
                        medicaments.Push(element);
                    }
                    else
                    {
                        textiles.Dequeue();
                        int temp = medicaments.Peek() + 10;
                        medicaments.Pop();
                        medicaments.Push(temp);
                    }
                }
            }

            if (medicaments.Count == 0 && textiles.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (medicaments.Count != 0)
            {
                Console.WriteLine("Textiles are empty.");
            }
            else
            {
                Console.WriteLine("Medicaments are empty.");
            }
            if (medicamentsList.Any(x => x.Count > 0))
            {
                foreach (var test in medicamentsList.Where(x => x.Count > 0).OrderByDescending(x => x.Count).ThenBy(x => x.Name))
                {
                    Console.WriteLine($"{test.Name} - {test.Count}");
                }
            }
            if (medicaments.Count == 0 && textiles.Count == 0)
            {
                return;
            }
            if (medicaments.Count != 0)
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ",medicaments)}");
            }
            else
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }

        class Medicaments
        {
            public string Name { get; set; }
            public int Count { get; set; }

            public Medicaments(string name)
            {
                this.Name = name;
                this.Count = 0;
            }
        }
    }
}
