using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }

        public Kindergarten(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Registry = new List<Child>();
        }
        public int ChildrenCount => this.Registry.Count;
        public bool AddChild(Child child)
        {
            if (this.Capacity > this.Registry.Count)
            {
                this.Registry.Add(child);
                return true;
            }
            return false;
        }
        public bool RemoveChild(string childFullName)
        {
            string[] splitter = childFullName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstName = splitter[0];
            string lastName = splitter[1];
            if (this.Registry.Any(x => x.FirstName == firstName && x.LastName == lastName))
            {
                this.Registry.Remove(
                    this.Registry.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName));
                return true;
            }
            return false;
        }
        public Child GetChild(string childFullName)
        {
            string[] splitter = childFullName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstName = splitter[0];
            string lastName = splitter[1];
            return this.Registry.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {this.Name}:");
            foreach (var test in this.Registry.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x => x.FirstName))
            {
                sb.AppendLine(test.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
