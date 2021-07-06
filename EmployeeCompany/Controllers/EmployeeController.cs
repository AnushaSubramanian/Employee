using EmployeeCompany.Model.Resource;
using EmployeeCompany.Model.Response;
using EmployeeCompany.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCompany.Controllers
{
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmpCompanyService _empCompanyService;
		public EmployeeController(IEmpCompanyService empCompanyService )
		{
			_empCompanyService = empCompanyService;
		}


		[HttpGet("api/v1/employee/fetch")]
		[ProducesResponseType(typeof(Response<IEnumerable<EmployeeResource>>), StatusCodes.Status200OK)]
		public async Task<IActionResult> ListAsync()
		{
			var result = await _empCompanyService.GetEmployee();
			return Ok(result);
		}

		[HttpPost("api/v1/employee/{name}/company/{company_id}")]
		[ProducesResponseType(typeof(Response<EmployeeResource>), StatusCodes.Status201Created)]
		public async Task<IActionResult> PostAsync(Guid company_id, string name)
		{
			var result = await _empCompanyService.PostEmployee(name, company_id);
			return Created("", result);
		}

        [HttpPut("api/v1/employee/{emp_id}/update")]
        [ProducesResponseType(typeof(Response<IEnumerable<EmployeeResource>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAsync(Guid emp_id, UpdateEmployee updateEmployee)
        {
			var result = await _empCompanyService.PutEmployee(emp_id, updateEmployee);
            return Ok(result);
        }
		[HttpDelete("api/v1/employee/{emp_id}/delete")]
		[ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
		public async Task<IActionResult> DeleteAsync(Guid emp_id)
		{
			var result = await _empCompanyService.DeleteEmployee(emp_id);
			return Ok(result);
		}
	}
}
