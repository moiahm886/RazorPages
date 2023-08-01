using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Model.Domain;

namespace RazorPages.Pages.Employees
{
    public class ListModel : PageModel
    {
        private readonly DbContextRazor dbContextRazor;
        public List<Employee> Emp { get; set; }

        public ListModel(DbContextRazor dbContextRazor)
        {
            this.dbContextRazor = dbContextRazor;
        }
        public void OnGet()
        {
            Emp = dbContextRazor.EMPLOYEE.ToList();

        }
    }
}
