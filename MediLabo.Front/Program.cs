
using MediLabo.Front.Clients;
using MediLabo.Front.Components;

var builder = WebApplication.CreateBuilder(args);

var gatewayUrl = builder.Configuration["GatewayUrl"]
    ?? throw new InvalidOperationException("Adresse de la gateway 'GatewayUrl' introuvable.");

var gatewayUri = new Uri(gatewayUrl);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<PatientsClient>(client =>
    client.BaseAddress = gatewayUri);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
