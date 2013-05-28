using System;

namespace WinForm
{
    public class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Position { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public int YearsInCompany { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
    }

    public class EmployeeViewItem
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int YearsInCompany { get; set; }
        public string StartDate { get; set; }
    }

    public class PersonDTO
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }
}
