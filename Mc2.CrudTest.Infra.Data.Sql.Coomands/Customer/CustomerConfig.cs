using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infra.Data.Sql.Coomands.Customer;
public class CustomerConfig : IEntityTypeConfiguration<Core.Domain.Entities.Customer>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Entities.Customer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(250);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(500);
        builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(12);
        builder.Property(x => x.Email).HasMaxLength(200);
        builder.Property(x => x.BankAcountNumber).HasMaxLength(50);

        builder.HasIndex(x => new { x.FirstName, x.LastName, x.DateOfBirth }).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
    }
}
