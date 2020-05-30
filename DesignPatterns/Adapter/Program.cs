using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    // 'Adaptee' class
    class ThirdPartyEmployee
    {
        public List<string> GetEmployeeList()
        {
            List<string> EmployeeList = new List<string>();
            EmployeeList.Add("Peter");
            EmployeeList.Add("Paul");
            EmployeeList.Add("Puru");
            EmployeeList.Add("Preethi");
            return EmployeeList;
        }
    }

    // 'ITarget Interface'
    interface ITarget
    {
        List<string> GetEmployees();
    }

    // 'Adapter' class
    class EmployeeAdapter : ThirdPartyEmployee, ITarget
    {
        public List<string> GetEmployees()
        {
            return GetEmployeeList();
        }
    }

    // 'Client' class
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee list from 3rd party organizaton system.");
            Console.WriteLine("------------------------------------------------");

            // Client will use the ITarget interface to call the functionality of 
            // Adaptee class i.e. ThirdPartyEmployee
            ITarget adapter = new EmployeeAdapter();

            foreach (string employee in adapter.GetEmployees())
            {
                Console.WriteLine(employee);
            }

            Console.ReadLine();
        }
    }
}
