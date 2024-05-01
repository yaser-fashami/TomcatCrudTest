using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mc2.CrudTest.Infra.Data.Sql.Coomands.Common;
public class BankAcountNumberConversion : ValueConverter<BankAcountNumber, string>
{
    public BankAcountNumberConversion():base(c=>c.Value, c=>BankAcountNumber.FrimString(c))
    {
        
    }
}
