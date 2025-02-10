using EventEase;
using EventEase.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<EventService>();
builder.Services.AddSingleton<UserSessionService>();
builder.Services.AddSingleton<AttendanceService>();
builder.Services.AddSingleton<SessionStorageService>();

await builder.Build().RunAsync();
