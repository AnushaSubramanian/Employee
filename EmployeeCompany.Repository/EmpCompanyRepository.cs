

using DynamicContent.Repository.Repositories;
using EmployeeCompany.DB;
using EmployeeCompany.Model;

namespace EmployeeCompany.Repository
{
	public class EmpCompanyRepository : BaseRepository<Company>, IEmpCompanyRepository
	{
		private DataContext _context;
		public EmpCompanyRepository(DataContext context) : base(context)
		{
			_context = context;
		}
	}
}
