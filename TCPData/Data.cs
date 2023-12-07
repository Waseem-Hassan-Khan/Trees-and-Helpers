using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPData
{
    public class Data
    {
        public static List<Employee> GetEmployess()
        {
            List<Employee> employees = new List<Employee>
            {
                  new Employee { Id = 1, FirstName = "John", LastName = "Doe", AnnualSalary = 50000, IsManager = true, Department = 1 },
                  new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", AnnualSalary = 45000, IsManager = false, Department = 2 },
                  new Employee { Id = 3, FirstName = "Robert", LastName = "Johnson", AnnualSalary = 55000, IsManager = true, Department = 1 },
                  new Employee { Id = 4, FirstName = "Emily", LastName = "Davis", AnnualSalary = 48000, IsManager = false, Department = 3 },
                  new Employee { Id = 5, FirstName = "Michael", LastName = "Brown", AnnualSalary = 60000, IsManager = true, Department = 2 },
                  new Employee { Id = 6, FirstName = "Ashley", LastName = "Wilson", AnnualSalary = 42000, IsManager = false, Department = 1 },
                  new Employee { Id = 7, FirstName = "Daniel", LastName = "Anderson", AnnualSalary = 58000, IsManager = false, Department = 3 },
                  new Employee { Id = 8, FirstName = "Olivia", LastName = "Moore", AnnualSalary = 46000, IsManager = false, Department = 2 },
                  new Employee { Id = 9, FirstName = "Ethan", LastName = "Jackson", AnnualSalary = 52000, IsManager = true, Department = 1 },
                  new Employee { Id = 10, FirstName = "Sophia", LastName = "Martinez", AnnualSalary = 43000, IsManager = false, Department = 3 },
                  new Employee { Id = 11, FirstName = "Aiden", LastName = "Taylor", AnnualSalary = 56000, IsManager = false, Department = 2 },
                  new Employee { Id = 12, FirstName = "Ava", LastName = "Harris", AnnualSalary = 49000, IsManager = false, Department = 1 },
                  new Employee { Id = 13, FirstName = "Liam", LastName = "Nelson", AnnualSalary = 53000, IsManager = true, Department = 3 },
                  new Employee { Id = 14, FirstName = "Isabella", LastName = "Turner", AnnualSalary = 44000, IsManager = false, Department = 2 },
                  new Employee { Id = 15, FirstName = "Mason", LastName = "White", AnnualSalary = 57000, IsManager = false, Department = 1 }
            };

            return employees;
        }

        public static List<Department> GetDepartments()
        {
            var departments = new List<Department>
              {
                    new Department { Id = 1, ShortName = "HR", LongName = "Human Resource" },
                    new Department { Id = 2, ShortName = "IT", LongName = "Information Technology" },
                    new Department { Id = 3, ShortName = "FIN", LongName = "Finance" },
                    new Department { Id = 4, ShortName = "SALES", LongName = "Sales" },
                    new Department { Id = 5, ShortName = "ENG", LongName = "Engineering" }
              };
            return departments;
        }
    }
}
