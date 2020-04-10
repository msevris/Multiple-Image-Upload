using Microsoft.EntityFrameworkCore;
using MultipleImageUpload.v1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleImageUpload.v1._0.Data
{
    public class EmployeeContextData : DbContext
    {
        public EmployeeContextData(DbContextOptions<EmployeeContextData> options)
            :base (options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Image> Images { get; set; }


    }
}
