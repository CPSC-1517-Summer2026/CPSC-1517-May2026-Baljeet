using WestWindWebApp.Components;
using ClassWestWindSystem;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//retrieve the connection string from the appsetting.json
//the connection string will be passed to the class library using
//  the encapsulated extension method
//the connection string will be registered to get access to the database
var connectionstring = builder.Configuration.GetConnectionString("WWDB");

//setup the registration of the services to be available for use
//  by this web application
//the technique used in this example has the registrations encapsulated
//  within the class library via an extension method
//technically, you could put all the setup that is in the extension method
//  here in this file
builder.Services.WWExtensionServices(options => options.UseSqlServer(connectionstring));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
