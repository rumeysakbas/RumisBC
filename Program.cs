using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

var openAiKey = builder.Configuration["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"];
builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri("https://api.openai.com/v1/"),
    DefaultRequestHeaders =
    {
        Authorization = new AuthenticationHeaderValue("Bearer", openAiKey)
    }
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
