using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Model.Domain;
using RazorPages.Model.ModelViews;

namespace RazorPages.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly DbContextRazor dbContextRazor;
        [BindProperty]
        public EditEmployeeViewModel Edit { get; set; }

        public EditModel(DbContextRazor dbContextRazor)
        {
            this.dbContextRazor = dbContextRazor;
        }
        public void OnGet(string Ssn)
        {
            var emp = dbContextRazor.EMPLOYEE.Find(Ssn);
            if (emp != null)
            {
                Edit = new EditEmployeeViewModel
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

                    existingEmployee.Fname = Edit.Fname;
                    existingEmployee.Minit = Edit.Minit;
                    existingEmployee.Lname = Edit.Lname;
                    existingEmployee.Salary = Edit.Salary;
                    existingEmployee.Sex = Edit.Sex;
                    existingEmployee.Bdate = Edit.Bdate;
                    existingEmployee.Address = Edit.Address;
                    existingEmployee.Super_ssn = Edit.Super_ssn;
                    existingEmployee.Dno = Edit.Dno;

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
