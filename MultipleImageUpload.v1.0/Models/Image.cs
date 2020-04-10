using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleImageUpload.v1._0.Models
{
    public class Image
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
