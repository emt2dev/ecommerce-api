using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.DAL.Models.Configurations
{
    public class RoleSeeder : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
                new IdentityRole
                {
                    Name = "Developer",
                    NormalizedName = "DEVELOPER"
                },
                new IdentityRole
                {
                    Name = "Owner",
                    NormalizedName = "OWNER"
                },
                new IdentityRole
                {
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Name = "Shopper",
                    NormalizedName = "SHOPPER"
                }
            );
    }
}
}
