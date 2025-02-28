using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;

namespace Assignment_3_EF_Core
{
    internal class Program
    {
        private static DbContextOptions<ITIDbContext> options;

        static void Main(string[] args)
        {
            #region Lazy Loading
            using (var context = new ITIDbContext(options))
            {
                var employee = context.Employees.FirstOrDefault(e => e.EmployeeId == 1);

                Console.WriteLine(employee.Name);

                foreach (var empDept in employee.EmployeeDepartments)
                {
                    Console.WriteLine(empDept.DepartmentId);
                }
            }
            #endregion

            #region Eager Loading
            using (var context = new ITIDbContext(options))
            {
                var employees = context.Employees
                                       .Include(e => e.EmployeeDepartments)
                                       .ThenInclude(ed => ed.Department)
                                       .ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine($"Employee: {employee.Name}");

                    foreach (var empDept in employee.EmployeeDepartments)
                    {
                        Console.WriteLine($"  - Department: {empDept.Department.Name}");
                    }
                }
            }

            #endregion
        }
    }
}

