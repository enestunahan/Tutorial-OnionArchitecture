using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(

                    new Employee
                    {
                        Id = new Guid("C58EB020-671C-436F-A303-33BF35E58B00"),
                        ProjectId = new Guid("58F88377-D2B9-4AA0-BCD0-0EA0F46F4476"),
                        FirstName = "Ahmet",
                        LastName = "Yıldırım",
                        Age = 30,
                        Position = "Senior Developer"    
                    }

                );
        }
    }
}
