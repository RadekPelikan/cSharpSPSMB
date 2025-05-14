using SpsmbBlog;
using SpsmbBlog.DB;
using SpsmbBlog.DB.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// builder.Services.AddTransient(); // Vytváří instanci pro každou získanou službu
// builder.Services.AddSingleton(); // Vytváří instanci pouze jednou na začátku procesu
// builder.Services.AddScoped();    // Vytváří instanci pro každý jeden request nebo jiný definovaný scope

DbDriver dbDriver;
while (true)
{
    var password = Helpers.ReadSecret("Enter db password: ");
    dbDriver = new DbDriver(password);
    if (dbDriver.CanConnect())
        break;
    Console.WriteLine("Password is incorrect. Please try again.");
}
Console.WriteLine("Logged into database successfully.");
builder.Services.AddSingleton<BlogRepository>(provider => new BlogRepository(dbDriver));


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
        name: "default",
        pattern: "{controller=Index}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();