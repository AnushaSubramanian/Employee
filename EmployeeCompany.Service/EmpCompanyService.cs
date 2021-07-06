
using EmployeeCompany.Model;
using EmployeeCompany.Model.Resource;
using EmployeeCompany.Model.Response;
using EmployeeCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCompany.Service
{
	public class EmpCompanyService : IEmpCompanyService
	{
		private readonly IEmployeeRepository  _employeeRepo;
		private readonly IEmpCompanyRepository _companyRepository;
		public EmpCompanyService(IEmployeeRepository employeeRepo, IEmpCompanyRepository companyRepository)
		{
			_employeeRepo = employeeRepo;
			_companyRepository = companyRepository;
		}

		/// <summary>
		/// fetch employee detail
		/// </summary>
		/// <returns></returns>
		public async Task<Response<IEnumerable<EmployeeResource>>> GetEmployee()
		{
			Response<IEnumerable<EmployeeResource>> response;
			var empList = await _employeeRepo.GetAllEmployees();
			var resource = empList.Select(o => new EmployeeResource() { EmployeeId = o.UUID, EmployeeName = o.EmpName, CompanyName = o.CompanyMapping.CompanyName });
			response =  new Response<IEnumerable<EmployeeResource>>();
			response.result = resource;
			response.success = true;
			return response;
		}
		/// <summary>
		/// post employee detail
		/// </summary>
		/// <param name="name"></param>
		/// <param name="comp_id"></param>
		/// <returns></returns>
		public async Task<Response<EmployeeResource>> PostEmployee(string name, Guid comp_id)
		{
			Response<EmployeeResource> response  = new Response<EmployeeResource>();
			if (string.IsNullOrEmpty(name))
			{
				response.success = false;
				response.result = null;
				return response;
			}
			var company = await _companyRepository.GetById(comp_id);
			if (company is null)
			{
				response.success = false;
				response.result = null;
				return response;
			}
			Guid empId = Guid.NewGuid();
			Employee employee = new Employee()
			{
				Comp_Id = comp_id,
				UUID = empId,
				CreatedAt = DateTime.Now,
				EmpName = name,
				CreatedBy = ""
			};

			await _employeeRepo.AddAsync(employee);
			var resource = new EmployeeResource() { EmployeeId = empId, CompanyName = company.CompanyName, EmployeeName = name };
			
			response.result = resource;
			response.success = true;
			return response;

		}
		/// <summary>
		///  update employee detail
		/// </summary>
		/// <param name="emp_id"></param>
		/// <param name="updateEmployee"></param>
		/// <returns></returns>
		public async Task<Response<EmployeeResource>> PutEmployee(Guid emp_id, UpdateEmployee updateEmployee)
		{
			Response<EmployeeResource> response  = new Response<EmployeeResource>();
			if (string.IsNullOrEmpty(updateEmployee.EmployeeName))
			{
				response.success = false;
				response.result = null;
				return response;
			}
			var employee = await _employeeRepo.GetById(emp_id);
			if (employee is null)
			{
				response.success = false;
				response.result = null;
				return response;
			}
			var company = _companyRepository.Find(o => o.UUID == updateEmployee.CompanyId).FirstOrDefault();
			if (company is null)
			{
				response.success = false;
				response.result = null;
				return response;
			}
			Employee employeeSave = new Employee()
			{
				Comp_Id = updateEmployee.CompanyId,
				UUID = emp_id,
				EditedAt = DateTime.Now,
				EmpName = updateEmployee.EmployeeName
			};

			await _employeeRepo.UpdateAsync(employeeSave);
			var resource = new EmployeeResource() { EmployeeId = employee.UUID, CompanyName = company.CompanyName, EmployeeName = updateEmployee.EmployeeName };

			response.result = resource;
			response.success = true;
			return response;
		}

		public async Task<Response<string>> DeleteEmployee(Guid emp_id)
		{
			Response<string> response = new Response<string>();
			var employee = await _employeeRepo.GetById(emp_id);
			if (employee is null)
			{
				response.success = false;
				response.result = "Not Deleted";
				return response;
			}
			_employeeRepo.Remove(employee);
			response.result = string.Format("Employee Deleted: {0}", employee.EmpName);
			response.success = true;
			return response;
		}
	}
}
