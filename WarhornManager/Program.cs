using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WarhornManager;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//HttpClient for use
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//State Management with StorageCrate class (in memory, for user; dependancy injected)
builder.Services.AddScoped<StorageCrate>();
//3rd party NuGet package for local storage
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
