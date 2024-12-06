using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Ajoutez les services nécessaires à l'application
builder.Services.AddControllersWithViews();

// Ajouter la gestion de la session
builder.Services.AddDistributedMemoryCache();  // Cache pour les cookies de session
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;  // Nécessaire pour les cookies de session
});

var app = builder.Build();


// Activer les sessions
app.UseSession();

// Ajouter la prise en charge de HTTPS et des fichiers statiques
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configurer les routes des contrôleurs et des vues
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
