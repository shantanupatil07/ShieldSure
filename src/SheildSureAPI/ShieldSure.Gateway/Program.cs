var builder = WebApplication.CreateBuilder(args);

// 1. Add Reverse Proxy services
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// --- THE FIX IS HERE ---
// This tells ASP.NET Core to actually use the YARP rules you defined in appsettings.json
app.MapReverseProxy();
// -----------------------

app.Run();