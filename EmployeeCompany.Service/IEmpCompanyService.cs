
using EmployeeCompany.Model;
using EmployeeCompany.Model.Resource;
using EmployeeCompany.Model.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCompany.Service
{
	public interface IEmpCompanyService
	{
		Task<Response<IEnumerable<EmployeeResource>>> GetEmployee();
		Task<Response<EmployeeResource>> PostEmployee(string name, Guid comp_id);
		Task<Response<EmployeeResource>> PutEmployee(Guid emp_id, UpdateEmployee updateEmployee);
		Task<Response<string>> DeleteEmployee(Guid emp_id);
	}
}
