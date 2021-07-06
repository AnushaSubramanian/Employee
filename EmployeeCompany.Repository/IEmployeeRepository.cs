

using EmployeeCompany.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCompany.Repository
{
	public interface IEmployeeRepository : IBaseRepository<Employee>
	{
		Task<IEnumerable<Employee>> GetAllEmployees();
	}
}
