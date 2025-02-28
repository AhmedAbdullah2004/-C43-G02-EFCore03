using System.Net;

namespace Assignment_3_EF_Core
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }

        public Address EmpAddress { get; set; }

        public List<EmployeeDepartment> EmployeeDepartments { get; set; } = new List<EmployeeDepartment>();
        public int EmployeeId { get; internal set; }
        public bool Name { get; internal set; }
    }

    public class Address
    {

            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
        
    }

}


    