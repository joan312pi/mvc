using LabMVC.Models.NorthwindDbContext;
using LabMVC.Models.Repository;
using LabMVC.Models.Repository.IRepository;
using LabMVC.Models.Service;
using LabMVC.Models.Service.IService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddDbContext<NorthwindDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind")));

builder.Services.AddScoped<INorthwindEmployeeRepository, NorthwindEmployeeRepository>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(NorthwindGenericRepository<>));

builder.Services.AddScoped<IGenericRepository<Customer> , NorthwindGenericRepository<Customer>>();

builder.Services.AddScoped<IGenericRepository<Employee> , NorthwindGenericRepository<Employee>>();

builder.Services.AddScoped<IGenericRepository<Order>, NorthwindGenericRepository<Order>>();


builder.Services.AddScoped<INotification , SmsNotificationService>();

//builder.Services.AddScoped<EmailNotificationService>();
//builder.Services.AddScoped<SmsNotificationService>();

//builder.Services.AddScoped<INotification>
//    (provider => provider.GetRequiredService<EmailNotificationService>());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.UseSession();


app.MapControllerRoute(
    name:"myIndexAreas",
    pattern: "Index/{area:exists}",
    defaults:new {controller="Account" , Action="Index"}
    );

app.MapControllerRoute(
    name:"areas",
    pattern: "{area:exists}/{controller}/{action=index}/{id?}"
    );


app.MapControllerRoute(
    name: "MyRoute",
    pattern: "MyAction/{action=index}/{id?}",
    defaults: new { controller = "Home" }
    );

app.MapControllerRoute(
    name: "NewRoute",
    pattern: "NameAndId/{id?}/{name?}",
    defaults: new { controller = "Home", action = "MyAction02" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
