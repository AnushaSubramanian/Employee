using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCompany.Model
{
	[Table("tbl_employee")]
	public class Employee : BaseEntity
	{		
		public string EmpName { get; set; }

		[MaxLength(50), Column("comp_id", TypeName = "varchar(50)"), ForeignKey("CompanyMapping")]
		public Guid Comp_Id { get; set; }
		public Company CompanyMapping { get; set; }
	}
}
