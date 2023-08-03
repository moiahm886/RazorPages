using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Model.Domain;
using RazorPages.Model.ModelViews;
using System.Dynamic;

namespace RazorPages.Pages.Employees
{
    public class AddModel : PageModel
    {
        private readonly DbContextRazor dbContextRazor;

        public AddModel(DbContextRazor dbContextRazor)
        {
            this.dbContextRazor = dbContextRazor;
        }
        [BindProperty]
        public SharedEmployeeClasss AddEmployeeRequest { get; set; }
        public void OnGet()
        {
        }
        public void OnPost() {
            dynamic emp = new ExpandoObject();
            emp.Fname = AddEmployeeRequest.Fname;
            emp.Minit = AddEmployeeRequest.Minit;
            emp.Lname = AddEmployeeRequest.Lname;
            emp.Ssn = AddEmployeeRequest.Ssn;
            emp.Bdate = AddEmployeeRequest.Bdate;
            emp.Address = AddEmployeeRequest.Address;
            emp.Sex = AddEmployeeRequest.Sex;
            emp.Salary = AddEmployeeRequest.Salary;
            emp.Super_ssn = AddEmployeeRequest.Super_ssn;
            emp.Dno = AddEmployeeRequest.Dno;
            dbContextRazor.EMPLOYEE.Add(emp);
            dbContextRazor.SaveChanges();
        }
    }
}
