using HRAdministrationAPI;
using Trees.Abstraction;
using Trees.Delegates;
using Trees.HRAdministrationAPI;
using static System.Runtime.InteropServices.JavaScript.JSType;

//Change the class name ProgramTempr to Program and main function MainTempr to Main to get it start working
class ProgramTempr
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster
    }
    static void MainTempr()
    {
        decimal totalSalaries = 0M;
        List<IEmployee> employees = new List<IEmployee>();
        seedData(employees);
        foreach (var employee in employees)
        {
            totalSalaries += employee.Salary;
        }
        Console.WriteLine($"Total Annual Salaries (Including Bonuses) : ${totalSalaries} using normal loop");

        Console.WriteLine($"Total Annual Salaries (Including Bonuses) : ${employees.Sum(e => e.Salary)} using LINQ");
    }

    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
        {
            IEmployee employee = null;
            #region Seed data into employee list using functions
            //switch(employeeType){
            //    case EmployeeType.Teacher:
            //        employee = new Teacher { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
            //        break;
            //    case EmployeeType.HeadMaster:
            //        employee = new Teacher { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
            //        break;
            //    case EmployeeType.HeadOfDepartment:
            //        employee = new Teacher { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
            //        break;
            //    case EmployeeType.DeputyHeadMaster:
            //        employee = new Teacher { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
            //        break;
            //    default:
            //        break;
            //}

            #endregion
            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    break;
                case EmployeeType.HeadMaster:
                    employee = new Teacher { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    break;
                case EmployeeType.HeadOfDepartment:
                    employee = new Teacher { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    break;
                case EmployeeType.DeputyHeadMaster:
                    employee = new Teacher { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    break;
                default:
                    break;
            }
            if (employee != null)
            {
                id = employee.Id;
                firstName = employee.FirstName;
                lastName = employee.LastName;
                salary = employee.Salary;
            }
            else
            {
                throw new NullReferenceException();
            }
            return employee;
        }
    }
    public static void seedData(List<IEmployee> employees)
    {
        #region Seed data into employee list using normal objects
        //IEmployee teacher1 = new Teacher
        //{
        //    Id = 1,
        //    FirstName = "Bob",
        //    LastName = "Fisher",
        //    Salary = 4000
        //};
        //employees.Add(teacher1);

        //IEmployee teacher2 = new Teacher
        //{
        //    Id = 2,
        //    FirstName = "Alice",
        //    LastName = "Johnson",
        //    Salary = 4500
        //};
        //employees.Add(teacher2);

        //IEmployee teacher3 = new Teacher
        //{
        //    Id = 3,
        //    FirstName = "Charlie",
        //    LastName = "Smith",
        //    Salary = 4200
        //};
        //employees.Add(teacher3);

        //IEmployee teacher4 = new Teacher
        //{
        //    Id = 4,
        //    FirstName = "David",
        //    LastName = "Jones",
        //    Salary = 4100
        //};
        //employees.Add(teacher4);

        //IEmployee teacher5 = new Teacher
        //{
        //    Id = 5,
        //    FirstName = "Eva",
        //    LastName = "Miller",
        //    Salary = 4300
        //};
        //employees.Add(teacher5);

        //IEmployee teacher6 = new Teacher
        //{
        //    Id = 6,
        //    FirstName = "Frank",
        //    LastName = "Brown",
        //    Salary = 4400
        //};
        //employees.Add(teacher6);

        //IEmployee teacher7 = new Teacher
        //{
        //    Id = 7,
        //    FirstName = "Grace",
        //    LastName = "Davis",
        //    Salary = 4600
        //};
        //employees.Add(teacher7);
        #endregion

        IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Bob", "Fisher", 4000);
        employees.Add(teacher1);
        IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 2, "Alice", "Johnson", 4500);
        employees.Add(teacher2);
        IEmployee teacher3 = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 3, "Charlie", "Smith", 4200);
        employees.Add(teacher3);
        IEmployee teacher4 = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 4, "David", "Jones", 4100);
        employees.Add(teacher4);
        IEmployee teacher5 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 5, "Eva", "Miller", 4300);
        employees.Add(teacher5);
        IEmployee teacher6 = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 6, "Frank", "Brown", 4400);
        employees.Add(teacher6);
        IEmployee teacher7 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 7, "Grace", "Davis", 4600);
        employees.Add(teacher7);
    }

}
