using System;

namespace EmployeeCompany.Model.Resource
{
   public  class UpdateEmployee
    {
        public string EmployeeName { get; set; }
        public Guid CompanyId { get; set; }
    }
}
