using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP_FinalExam_Net6.Controllers;
using ASP_FinalExam_Net6.Data;
using ASP_FinalExam_Net6.Models;

namespace ASP_FinalExam_Net6.Tests
{
    public class EmployeesControllerTest
    {
        [Fact]
        public async Task Index_Returns_ViewResult()
        {
            using(var testDb = new ApplicationDbContext(this.GetTestDbOpts()))
            {
                var testCtrl = new EmployeesController(testDb);
                var fakeEmployees = MakeFakeEmployees(3);

                foreach(var employee in fakeEmployees)
                {
                    var res = await testCtrl.Create(employee)
;                   var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);
                }

                var idxRes = await testCtrl.Index();
                var idxResVr = Assert.IsType<ViewResult>(idxRes);
                var returnedEmployees = Assert.IsAssignableFrom<IEnumerable<Employee>>(idxResVr.ViewData.Model);
                foreach(var employee in returnedEmployees)
                {
                    var res = await testCtrl.DeleteConfirmed(employee.Id);
                    var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);
                }
            }
        }



        private DbContextOptions<ApplicationDbContext> GetTestDbOpts()
       {
            return new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Server=(localdb)\\mssqllocaldb;Database=aspnet-ASP_FinalExam_Net6-C00B432D-AD85-4FC7-BEB4-79B78C41E2BF;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            
        }

        private List<Employee> MakeFakeEmployees(int i)
        {
            var employees = new List<Employee>();

            for(int j=0; j<i; j++)
            {
                employees.Add(new Employee
                {
                    Name = $"test{j}",
                    isManager = false
                });
            }
            return employees;
        }
    }
}
