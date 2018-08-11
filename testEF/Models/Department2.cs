using System;
using System.Collections.Generic;

namespace testEF.Models
{
    public partial class Department2
    {
        public Department2()
        {
            Employee2 = new HashSet<Employee2>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee2> Employee2 { get; set; }
    }
}
