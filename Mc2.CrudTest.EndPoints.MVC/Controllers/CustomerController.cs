using Mc2.CrudTest.Core.Contracts.Customers.Commands;
using Mc2.CrudTest.Framework.EndPoints.WebMVC.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.EndPoints.MVC.Controllers;
public class CustomerController : BaseController
{
    public async Task<IActionResult> Index()
    {
        return Query();
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Post(CreateCustomerCommand createCustomer)
    {
        return await Create(createCustomer);
    }
}
