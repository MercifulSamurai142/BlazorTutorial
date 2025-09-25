using BlazorTutorial.Components;

var builder = WebApplication.CreateBuilder(args); //new instance of WebApplicationBuilder

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();//build the WebApplication

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();//middleware to redirect HTTP requests to HTTPS

app.UseStaticFiles();//middleware to serve static files
app.UseAntiforgery();//middleware to protect against CSRF attacks

app.MapRazorComponents<App>()//map the root component for Razor components
    .AddInteractiveServerRenderMode();

app.Run();
