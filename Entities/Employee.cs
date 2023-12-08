using System;
using System.Collections.Generic;

namespace Example.Models.Entities
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int? EmployeeCode { get; set; }
        public int? DepartmentId { get; set; }
        public int? Rank { get; set; }

        public virtual Department? Department { get; set; }
    }
}
