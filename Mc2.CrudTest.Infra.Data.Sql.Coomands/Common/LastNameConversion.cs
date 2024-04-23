using Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mc2.CrudTest.Infra.Data.Sql.Coomands.Common;
public class LastNameConversion : ValueConverter<LastName, string>
{
    public LastNameConversion() : base(c => c.Value, c => LastName.FromString(c))
    {

    }
}
