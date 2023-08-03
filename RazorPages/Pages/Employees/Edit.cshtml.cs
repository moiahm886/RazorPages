using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Model.Domain;
using RazorPages.Model.ModelViews;
using System.Dynamic;

namespace RazorPages.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly DbContextRazor dbContextRazor;
        [BindProperty]
        public SharedEmployeeClasss Edit { get; set; }

        public EditModel(DbContextRazor dbContextRazor)
        {
            this.dbContextRazor = dbContextRazor;
        }
        public void OnGet(string Ssn)
        {
            var emp = dbContextRazor.EMPLOYEE.Find(Ssn);
            if (emp != null)
            {
                Edit = new SharedEmployeeClasss
                {
                    Fname = emp.Fname,
                    Minit = emp.Minit,
                    Lname = emp.Lname,
                    Ssn = emp.Ssn,
                    Salary = emp.Salary,
                    Sex = emp.Sex,
                    Bdate = emp.Bdate,
                    Address = emp.Address,
                    Super_ssn = emp.Super_ssn,
                    Dno = emp.Dno,
                };
            }
        }
        public void OnPostUpdate()
        {
            if (Edit != null)
            {
                var existingEmployee = dbContextRazor.EMPLOYEE.Find(Edit.Ssn);
                if (existingEmployee != null)
                {
                    dynamic employeeData = new ExpandoObject();
                    employeeData.Fname = Edit.Fname;
                    employeeData.Minit = Edit.Minit;
                    employeeData.Lname = Edit.Lname;
                    employeeData.Salary = Edit.Salary;
                    employeeData.Sex = Edit.Sex;
                    employeeData.Bdate = Edit.Bdate;
                    employeeData.Address = Edit.Address;
                    employeeData.Super_ssn = Edit.Super_ssn;
                    employeeData.Dno = Edit.Dno;
                    foreach (var property in ((IDictionary<string, object>)employeeData))
                    {
                        var propertyName = property.Key;
                        var propertyValue = property.Value;
                        existingEmployee.GetType().GetProperty(propertyName)?.SetValue(existingEmployee, propertyValue);
                    }
                    dbContextRazor.SaveChanges();
                }
            }
        }
        public IActionResult OnPostDelete()
        {
            var existingEmployee = dbContextRazor.EMPLOYEE.Find(Edit.Ssn);
            if (existingEmployee != null)
            {
                dbContextRazor.EMPLOYEE.Remove(existingEmployee);
                dbContextRazor.SaveChanges();
                return RedirectToPage("/Employees/List");
            }
            return Page();
        }
    }
}
