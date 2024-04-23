using Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mc2.CrudTest.Infra.Data.Sql.Coomands.Common;
public class EmailConversion : ValueConverter<Email, string>
{
    public EmailConversion():base(c=>c.Value, c=>Email.FromString(c))
    {
        
    }
}
