var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
