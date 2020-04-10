using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultipleImageUpload.v1._0.Data;
using MultipleImageUpload.v1._0.Models;

namespace MultipleImageUpload.v1._0.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeContextData _context;
        private readonly IWebHostEnvironment _env;

        public CreateModel(EmployeeContextData context, IWebHostEnvironment environment)
        {
            _context = context;
            _env = environment;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        [BindProperty]
        public Image Image { get; set; }
        [BindProperty]
        public MultipleFileUpload FileUpload { get; set; }
        public void OnGet()
        {

        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var newEmployee = new Employee
                {
                    EmployeeName = Employee.EmployeeName
                };
                string uniqueFileName = null;

                foreach (var photo in FileUpload.Photos)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString().Substring(0, 5) + "_" + Path.GetFileName(photo.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    photo.CopyTo(new FileStream(filePath, FileMode.Create));

                    var newImages = new Image
                    {
                        ImagePath = uniqueFileName,
                        Employee = newEmployee
                    };
                    _context.Images.Add(newImages);
                }
                _context.Employees.Add(newEmployee);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
        public class MultipleFileUpload
        {
            public List<IFormFile> Photos { get; set; }
        }
    }
}