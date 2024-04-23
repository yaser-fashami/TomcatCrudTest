using Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mc2.CrudTest.Infra.Data.Sql.Coomands.Common;
public class PhoneNumberConversion : ValueConverter<PhoneNumber, string>
{
    public PhoneNumberConversion():base(c=>c.Value, c=>PhoneNumber.FromString(c))
    {
        
    }
}
