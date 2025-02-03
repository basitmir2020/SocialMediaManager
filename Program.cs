using Microsoft.AspNetCore.Authentication.Cookies;
using SocialMediaAutoPosterApp.Components;
using SocialMediaAutoPosterApp.Data;
using SocialMediaAutoPosterApp.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Use the extension method to register the DbContext and Identity services.
builder.Services
    .AddApplicationDataServices(builder.Configuration);

// Register application services
builder.Services
    .AddApplicationServices(); // This registers all services

// Add authentication services
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = "/login"; // Specify your login path
        options.AccessDeniedPath = "/access-denied"; // Specify your access denied path
    });

// Add authorization services
builder.Services.AddAuthorization();

// Add anti-forgery services
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN"; // Customize the anti-forgery token header name if needed
});

// Add Razor components and Blazor services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Ensure database is seeded on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        Console.WriteLine("Seeding data...");
        await DbInitializer.SeedData(services);
        Console.WriteLine("Seeding completed.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error during seeding: {ex.Message}");
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Add anti-forgery middleware
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();