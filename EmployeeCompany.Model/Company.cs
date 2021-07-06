
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCompany.Model
{
	[Table("tbl_company")]
	public class Company : BaseEntity
	{
		public string CompanyName { get; set; }
	}
}
