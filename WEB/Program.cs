using DataAccess.Models;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Exe;
using WEB.Services;
using WEB.Hubs;
using static WEB.Pages.ChatModel;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddLogging();
// Add services to the container.
builder.Services.AddDbContext<QuickMarketContext>();
builder.Services.AddRazorPages();

builder.Services.AddHostedService<CheckingPaymentService>();

// Add session and necessary services
builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(2000); // Set session timeout value
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // Make the session cookie essential
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.MapHub<WEB.Hubs.ChatHub>("/chatHub");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession(); 

app.MapRazorPages();

app.Run();
