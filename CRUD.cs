using Assignment_3_EF_Core;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository
{
    private readonly ITIDbContext _context;

    public EmployeeRepository(ITIDbContext context)
    {
        _context = context;
    }

    public void AddEmployee(Employee employee, int departmentId)
    {
        var department = _context.Departments.Find(departmentId);
        if (department == null) return;

        var employeeDepartment = new EmployeeDepartment
        {
            Employee = employee,
            Department = department
        };

        _context.EmployeeDepartments.Add(employeeDepartment);
        _context.SaveChanges();
    }

    public List<Employee> GetEmployeesWithDepartments()
    {
        return _context.Employees
            .Include(e => e.EmployeeDepartments)
            .ThenInclude(ed => ed.Department)
            .ToList();
    }

    public void UpdateEmployeeSalary(int employeeId, decimal newSalary)
    {
        var employee = _context.Employees.Find(employeeId);
        if (employee != null)
        {
            employee.Salary = newSalary;
            _context.SaveChanges();
        }
    }

    public void DeleteEmployee(int employeeId)
    {
        var employee = _context.Employees.Find(employeeId);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}
