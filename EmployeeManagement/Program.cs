using EmployeeManagement.Context;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
#region Services
builder.Services.AddMvc(MvcOptions => MvcOptions.EnableEndpointRouting=false).AddXmlSerializerFormatters() ;
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmpDBConnection")));
builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>(); 
#endregion
var app = builder.Build();
#region Middelware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();    
}

app.UseFileServer();//UseDefaultFiles+UseStaticFiles
app.UseMvc(routes => routes.MapRoute(name: "default", template: "{controller=home}/{action=index}/{id?}"));

    
//app.UseMvcWithDefaultRoute();

app.Run();
#endregion
