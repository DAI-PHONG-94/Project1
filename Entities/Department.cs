using System;
using System.Collections.Generic;

namespace Example.Models.Entities
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? DepartmentCode { get; set; }
        public string? Location { get; set; }
        public string? NumberOfPersonals { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
