

using DynamicContent.Repository.Repositories;
using EmployeeCompany.DB;
using EmployeeCompany.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCompany.Repository
{
	public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
	{
		private DataContext _context;
		public EmployeeRepository(DataContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
			var result = await _context.Employee
				.Include(o => o.CompanyMapping).ToListAsync();
			return result;
        }

	}
}
