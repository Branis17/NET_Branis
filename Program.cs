using Microsoft.EntityFrameworkCore;
using mvcTemplate.Data;

var builder = WebApplication.CreateBuilder(args);

// Ajouter AppDbContext comme service
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33)) // Assurez-vous que la version est correcte pour votre serveur MySQL
    ));

// Ajouter les services pour les contrôleurs avec vues
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure le pipeline de traitement des requêtes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
