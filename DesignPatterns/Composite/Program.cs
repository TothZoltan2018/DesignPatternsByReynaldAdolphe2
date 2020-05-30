using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    // 'IComponent' interface
    public interface IEmployee
    {
        int EmployeeId { get; set; }
        string Name { get; set; }
        int Rating { get; set; }
        void PerformanceSummary();
    }

    // 'Leaf' class - will be a leaf node in tree structure
    public class Employee : IEmployee
    {        
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public void PerformanceSummary()
        {
            Console.WriteLine($"\nPerformance summary of employee: {Name} is {Rating} out of 5");
        }
    }

    // 'Composite' class
    public class SuperVisor : IEmployee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public List<IEmployee> ListSubordinates = new List<IEmployee>();
        public void PerformanceSummary()
        {
            Console.WriteLine($"\nPerformance summary of supervisor: {Name} is {Rating} out of 5");
        }

        public void AddSubordinate(IEmployee employee)
        {
            ListSubordinates.Add(employee);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee ricky = new Employee { EmployeeId = 1, Name = "ricky", Rating = 3 };
            Employee mike = new Employee { EmployeeId = 2, Name = "mike", Rating = 4 };
            Employee maryann = new Employee { EmployeeId = 3, Name = "maryann", Rating = 5 };
            Employee ginger = new Employee { EmployeeId = 4, Name = "ginger", Rating = 3 };
            Employee olive = new Employee { EmployeeId = 5, Name = "olive", Rating = 4 };
            Employee candy = new Employee { EmployeeId = 6, Name = "candy", Rating = 5 };
            SuperVisor ronny = new SuperVisor { EmployeeId = 7, Name = "ronny", Rating = 3 };
            SuperVisor bobby = new SuperVisor { EmployeeId = 8, Name = "bobby", Rating = 3 };

            ronny.AddSubordinate(ricky);
            ronny.AddSubordinate(mike);
            ronny.AddSubordinate(maryann);

            bobby.AddSubordinate(ginger);
            bobby.AddSubordinate(olive);
            bobby.AddSubordinate(candy);

            Console.WriteLine($"\n--- Employee ca see their Performance Summary --------");
            ricky.PerformanceSummary();

            Console.WriteLine($"\n--- Supervisor ca see their Performance Summary --------");
            ronny.PerformanceSummary();

            Console.WriteLine("\nSubordinate Performance Record:");
            foreach (Employee employee in ronny.ListSubordinates)
            {
                employee.PerformanceSummary();
            }

            Console.ReadLine();
        }
    }
}
