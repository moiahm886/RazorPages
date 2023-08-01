using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Model.Domain;
using RazorPages.Model.ModelViews;
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
        public AddEmployeeModelView AddEmployeeRequest { get; set; }
        public void OnGet()
        {
        }
        public void OnPost() {
            var Emp = new Employee
            {
                Fname = AddEmployeeRequest.Fname,
                Minit = AddEmployeeRequest.Minit,
                Lname = AddEmployeeRequest.Lname,
                Ssn = AddEmployeeRequest.Ssn,
                Bdate = AddEmployeeRequest.Bdate,
                Address = AddEmployeeRequest.Address,
                Sex = AddEmployeeRequest.Sex,
                Salary = AddEmployeeRequest.Salary,
                Super_ssn = AddEmployeeRequest.Super_ssn,
                Dno = AddEmployeeRequest.Dno,
            };
            dbContextRazor.EMPLOYEE.Add(Emp);
            dbContextRazor.SaveChanges();
        }
    }
}
