using CleanArchMvc.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddRazorPages();
builder.Services.AddInfrastructure(configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "Default", pattern: "{controller=Clubs}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
