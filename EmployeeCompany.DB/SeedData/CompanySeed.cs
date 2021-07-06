using EmployeeCompany.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeCompany.DB.SeedData
{
    public static class CompanySeed
    {
        public static void ImportCompanyData(this ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Company>().HasData
			(
				new Company
				{
					UUID = Guid.Parse("13ad310c-d2bd-4c77-a9d4-5a4a9bb2323c"),
					CreatedAt = new DateTime(2020, 12, 17, 16, 54, 37, 199, DateTimeKind.Local).AddTicks(578),
					CreatedBy = "migration",
					CompanyName = "MilliPixel"
				}
			);
		}
    }
}
