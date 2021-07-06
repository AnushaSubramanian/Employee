using Microsoft.Extensions.DependencyInjection;

namespace EmployeeCompany.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<IEmpCompanyService, EmpCompanyService>();
            return services;
        }
    }
}
