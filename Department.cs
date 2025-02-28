using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_EF_Core
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<EmployeeDepartment> EmployeeDepartments { get; set; } = new List<EmployeeDepartment>();
    }
}
