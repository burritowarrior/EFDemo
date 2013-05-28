using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public List<Grade> Grades { get; set; }
    }

    public class Grade
    {
        public string ClassName { get; set; }
        public decimal Score { get; set; }
    }

    public class StudentOverview
    {
        public string StudentName { get; set; }
        public decimal StudentAverage { get; set; }
    }
}
