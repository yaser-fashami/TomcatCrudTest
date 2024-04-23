﻿using Mc2.CrudTest.Core.Domain.Customer.Entities;
using Mc2.CrudTest.Framework.Core.Contracts.Data.Commands;

namespace Mc2.CrudTest.Core.Contracts.Customers.CommandRepositories;
public interface ICustomerCommandRepository : ICommandRepository<Customer>
{
}
