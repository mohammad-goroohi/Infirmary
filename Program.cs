using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Infirmary;
using Infirmary.Services;
using Infirmary.Services.Shared;
using Infirmary.Models.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<RolesService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddSingleton<ToastService>();
builder.Services.AddSingleton<EditorModalService>();
builder.Services.AddSingleton<MainLayoutService>();
builder.Services.AddSingleton<GenericService>();
builder.Services.AddTransient<CrudService<BaseEntity>>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
