using Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;
using Mc2.CrudTest.Framework.Infra.Data.Sql.Commands;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infra.Data.Sql.Coomands.Common;
public class CrudTestCommandDbContext : BaseCommandDbContext
{
    public DbSet<Core.Domain.Customer.Entities.Customer> Customers { get; set; }

    public CrudTestCommandDbContext(DbContextOptions<CrudTestCommandDbContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<FirstName>().HaveConversion<FirstNameConversion>();
        configurationBuilder.Properties<LastName>().HaveConversion<LastNameConversion>();
        configurationBuilder.Properties<PhoneNumber>().HaveConversion<PhoneNumberConversion>();
        configurationBuilder.Properties<Email>().HaveConversion<EmailConversion>();
    }
}
