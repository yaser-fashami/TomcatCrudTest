using Mc2.CrudTest.Core.Contracts.Customers.Commands;
using Mc2.CrudTest.Core.Contracts.Customers.Queries;
using Mc2.CrudTest.Framework.EndPoints.WebMVC.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.EndPoints.MVC.Controllers;
public class CustomerController : BaseController
{
    private readonly ICustomerQueryRepository _customerQueryRepository;
    public CustomerController(ICustomerQueryRepository customerQueryRepository)
    {
        _customerQueryRepository = customerQueryRepository;
    }

    public async Task<IActionResult> Index()
    {
        var customers = await _customerQueryRepository.GetAllAsync();
        return View(customers);
    }

    public IActionResult AddCustomer()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCustomerCommand createCustomer)
    {
        var result = await Create(createCustomer);
        return RedirectToAction("index", result);
    }
}
