using Microsoft.AspNetCore.Hosting;
using WebapiCelulares;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigurateServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
