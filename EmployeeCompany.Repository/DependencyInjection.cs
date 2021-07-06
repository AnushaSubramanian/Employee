using Microsoft.Extensions.DependencyInjection;

namespace EmployeeCompany.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IEmpCompanyRepository, EmpCompanyRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
