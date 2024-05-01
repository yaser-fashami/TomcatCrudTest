using Mc2.CrudTest.Core.ApplicationService.Customer.Commands.CreateCustomer;
using Mc2.CrudTest.Core.Contracts.Customers.CommandRepositories;
using Mc2.CrudTest.Core.Contracts.Customers.Commands;
using Mc2.CrudTest.Core.Contracts.Customers.Queries;
using Mc2.CrudTest.Framework.Core.ApplicationServices.Commands;
using Mc2.CrudTest.Framework.Core.Contracts.ApplicationServices.Commands;
using Mc2.CrudTest.Framework.EndPoints.WebMVC;
using Mc2.CrudTest.Framework.EndPoints.WebMVC.Extensions.DependencyInjection;
using Mc2.CrudTest.Infra.Data.Sql.Coomands.Common;
using Mc2.CrudTest.Infra.Data.Sql.Coomands.Customer;
using Mc2.CrudTest.Infra.Data.Sql.Queries.Common;
using Mc2.CrudTest.Infra.Data.Sql.Queries.Customer;
using Microsoft.EntityFrameworkCore;

var builder = new FrameworkProgram().Main(args, "appsettings.json");

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CrudTestCommandDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("CustomerCommand_cnn")));
builder.Services.AddDbContext<CrudTestQueryDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("CustomerQuery_cnn")));

builder.Services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
builder.Services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
builder.Services.AddScoped<ICommandHandler<CreateCustomerCommand>, CreateCustomerCommandHandler>();

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();
