
using EmployeeCompany.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;



namespace Employee.Test
{
    public class EmployeeMockRepo
    {
        public static Mock<IEmployeeRepository> GetEmployeeData()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            IEnumerable<EmployeeCompany.Model.Employee> employees = new List<EmployeeCompany.Model.Employee>()
            {
                new EmployeeCompany.Model.Employee()
                {
                    UUID = Guid.Parse("dce31ead-bb94-11ea-9d36-68f72850fe34"),
                    CreatedAt=DateTime.UtcNow,
                    CreatedBy="Test",
                    EditedAt=DateTime.UtcNow,
                    EditedBy="Test",
                    EmpName = "Test_Name",
                    Comp_Id =  Guid.Parse("1d1d77df-c052-11ea-bbfb-68f72850fe34")
                }
            }.AsEnumerable();

            mockRepo.Setup(repo => repo.GetById(
                           It.IsAny<Guid>())).ReturnsAsync((Guid uuid) =>
                           employees.SingleOrDefault(x => x.UUID == uuid));
            mockRepo.Setup(repo => repo.GetAllEmployees()).ReturnsAsync(employees);
            mockRepo.SetupAllProperties();
            return mockRepo;
        }

        public static Mock<IEmpCompanyRepository> GetCompanyData()
        {
            var mockRepo = new Mock<IEmpCompanyRepository>();
            IEnumerable<EmployeeCompany.Model.Company> company = new List<EmployeeCompany.Model.Company>()
            {
                new EmployeeCompany.Model.Company()
                {
                    UUID = Guid.Parse("1d1d77df-c052-11ea-bbfb-68f72850fe34"),
                    CreatedAt=DateTime.UtcNow,
                    CreatedBy="Test",
                    EditedAt=DateTime.UtcNow,
                    EditedBy="Test",
                    CompanyName = "MilliPixel"
                }
            }.AsEnumerable();

            mockRepo.Setup(repo => repo.GetById(
                           It.IsAny<Guid>())).ReturnsAsync((Guid uuid) =>
                           company.SingleOrDefault(x => x.UUID == uuid));
            mockRepo.SetupAllProperties();
            return mockRepo;
        }
    }
}
