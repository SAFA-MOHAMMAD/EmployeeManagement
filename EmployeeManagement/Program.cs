using EmployeeManagement.Context;
using EmployeeManagement.Models;
using EmployeeManagement.Repository.Implemantation;
using EmployeeManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
#region Services
builder.Services.AddMvc(MvcOptions => MvcOptions.EnableEndpointRouting=false).AddXmlSerializerFormatters() ;
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmpDBConnection")));
builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
builder.Services.AddScoped<IRepository<Department>, DepartmentRepository>();


#endregion
var app = builder.Build();
#region Middelware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();    
}
else
{
    app.UseExceptionHandler("/Error");
   // app.UseStatusCodePagesWithRedirects("/Error/{0}");
}

app.UseFileServer();//UseDefaultFiles+UseStaticFiles
app.UseMvc(routes => routes.MapRoute(name: "default", template: "{controller=home}/{action=index}/{id?}"));

    
//app.UseMvcWithDefaultRoute();

app.Run();
#endregion
