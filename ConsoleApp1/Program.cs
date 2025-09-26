using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Employee
    {
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee> {
                new Employee{ Department = "HR", Salary = 8000},
                new Employee{ Department = "IT", Salary = 9000},
                new Employee{ Department = "HR", Salary = 7000},
                new Employee{ Department = "IT", Salary = 12000},
                new Employee{ Department = "Sales", Salary = 10000}
            };

            var list = employees.GroupBy(g => g.Department).Select(g =>
                new
                {
                    Department = g.Key,
                    AverageSalary = g.Average(e => e.Salary)
                }
            );

            foreach (var group in list)
                Console.WriteLine("{0} {1}", group.Department, group.AverageSalary);

            Console.ReadKey();
        }
    }
}
