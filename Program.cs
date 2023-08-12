using Budmar_app.Data;
using Budmar_app.Data.Mapper;
using Budmar_app.Repository;
using Budmar_app.Repository.Contracts;
using Budmar_app.Services;
using Budmar_app.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Budmar_app.ViewComponents;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IContractRepository, ContractRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IWorkHourService, WorkHourService>();

builder.Services.AddScoped<CreateEmployeeViewComponent>();
builder.Services.AddScoped<EditEmployeeViewComponent>();

builder.Services.AddScoped<CreateContractViewComponent>();

builder.Services.AddScoped<CreateWorkHourViewComponent>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
