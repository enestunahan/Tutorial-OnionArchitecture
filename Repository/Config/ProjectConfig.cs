using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData
                (
                    new Project
                    {
                        Id = new Guid("58F88377-D2B9-4AA0-BCD0-0EA0F46F4476"),
                        Name = "ASP.NET Core Web Api Project",
                        Description = "Web Application Programming Interface",
                        Field = "Computer Science",
                        ImageUrl = ""
                    }
                );
        }

        
    }
}
