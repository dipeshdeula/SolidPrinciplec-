using DigitalDataStructure.Security;
using DigitalDataStructure.SolidPrinciple;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

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
