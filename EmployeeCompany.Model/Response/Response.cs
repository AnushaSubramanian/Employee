

namespace EmployeeCompany.Model.Response
{
	public class Response<T>
	{
		public bool success { get; set; }
		public T result { get; set; }
	}
	public class Response
	{
		public bool success { get; set; }
		public string message { get; set; }
	}
}
