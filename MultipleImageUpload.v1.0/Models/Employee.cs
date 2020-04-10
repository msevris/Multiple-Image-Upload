using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleImageUpload.v1._0.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
