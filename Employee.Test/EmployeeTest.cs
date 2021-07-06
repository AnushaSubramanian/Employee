using EmployeeCompany.Controllers;
using EmployeeCompany.Model.Resource;
using EmployeeCompany.Service;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Employee.Test
{
    public class EmployeeTest
    {
        private EmployeeController _controller;
        private IEmpCompanyService _empCompanyService;
        [SetUp]
        public void Setup()
        {
            _empCompanyService = new EmpCompanyService(EmployeeMockRepo.GetEmployeeData().Object, EmployeeMockRepo.GetCompanyData().Object);
            _controller = new EmployeeController(_empCompanyService);
        }

        [Test]
        public async Task GetAllEmployees_Test()
        {
            var result = await _controller.ListAsync();
            var OkResult = result as OkObjectResult;
            var response = OkResult.Value;
            //Positive Test
            Assert.IsTrue(response != null);
            Assert.IsTrue(OkResult.StatusCode == 200);
        }
        [Test]
        public async Task PostEmployees_Test()
        {
            var comp_id = Guid.Parse("1d1d77df-c052-11ea-bbfb-68f72850fe34");
            var result = await _controller.PostAsync(comp_id, "Test_Emp");
            //Positive Test
            Assert.IsTrue(((ObjectResult)result).StatusCode == 201);
            Assert.IsTrue(((ObjectResult)result).Value != null);
        }
        [Test]
        public async Task PutEmployees_Test()
        {
            var emp_id = Guid.Parse("dce31ead-bb94-11ea-9d36-68f72850fe34");
            UpdateEmployee updateEmployee = new UpdateEmployee()
            {
                CompanyId = Guid.Parse("1d1d77df-c052-11ea-bbfb-68f72850fe34"),
                EmployeeName = "Updated_Name"
            };
            var result = await _controller.PutAsync(emp_id, updateEmployee);
            var OkResult = result as OkObjectResult;
            var response = OkResult.Value;
            //Positive Test
            Assert.IsTrue(response != null);
            Assert.IsTrue(OkResult.StatusCode == 200);
        }

        [Test]
        public async Task DeleteEmployees_Test()
        {
            var emp_id = Guid.Parse("dce31ead-bb94-11ea-9d36-68f72850fe34");
            var result = await _controller.DeleteAsync(emp_id);
            var OkResult = result as OkObjectResult;
            var response = OkResult.Value;
            //Positive Test
            Assert.IsTrue(response != null);
            Assert.IsTrue(OkResult.StatusCode == 200);
        }
    }
}