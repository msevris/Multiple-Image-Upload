using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MultipleImageUpload.v1._0.Data;
using MultipleImageUpload.v1._0.Models;

namespace MultipleImageUpload.v1._0.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeContextData _context;

        public IndexModel(EmployeeContextData context)
        {
            _context = context;
        }

        public IList<Image> Image { get;set; }

        public async Task OnGetAsync()
        {
            Image = await _context.Images
                .Include(i => i.Employee)
                .ToListAsync();
        }
    }
}
