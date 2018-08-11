using System;
using System.Collections.Generic;

namespace testEF.Models
{
    public partial class Employee2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        public Department2 Department { get; set; }
    }
}
