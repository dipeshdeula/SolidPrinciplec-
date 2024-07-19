using DigitalDataStructure.Models;
using DigitalDataStructure.Security;
using DigitalDataStructure.SolidPrinciple;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Database Injection
builder.Services.AddDbContext<CrudDigitalAppContext>(options => options.UseSqlServer(builder.Configuration["Conn"]));

//Dependency Injection
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

//security injection
builder.Services.AddSingleton<DataSecurityProvider>();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");


app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
        name: "default",
        pattern: "{Controller=Home}/{Action=Index}/{id?}"
    );

app.Run();
