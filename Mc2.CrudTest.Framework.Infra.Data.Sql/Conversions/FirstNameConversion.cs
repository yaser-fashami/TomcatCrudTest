﻿using Mc2.CrudTest.Framework.Core.Domain.Toolkits.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mc2.CrudTest.Framework.Infra.Data.Sql.Conversions;
public class FirstNameConversion : ValueConverter<FirstName, string>
{
    public FirstNameConversion() : base(c => c.Value, c => FirstName.FromString(c))
    {

    }
}
