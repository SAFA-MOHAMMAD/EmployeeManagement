using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
#region Services
builder.Services.AddMvc(MvcOptions => MvcOptions.EnableEndpointRouting=false).AddXmlSerializerFormatters() ;  
builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>(); 
#endregion
var app = builder.Build();
#region Middel
app.UseStaticFiles();
app.MapGet("/", () => "Employee Management");
DeveloperExceptionPageOptions options = new DeveloperExceptionPageOptions();
options.SourceCodeLineCount = 5;
app.UseDeveloperExceptionPage(options);//for error         
app.UseFileServer();//UseDefaultFiles+UseStaticFiles
app.UseMvcWithDefaultRoute();

app.Run();
#endregion
