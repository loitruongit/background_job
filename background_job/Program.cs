using background_job;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddRazorPages();
builder.Services.AddApiVersioning();
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddOpenApiDocument(configure =>
{
    configure.Title = "Demo - Background job API";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.UseOpenApi();
app.UseSwaggerUi3(settings =>
{
    settings.Path = "/api";
});

app.UseHangfireDashboard("/hangfire", new DashboardOptions { });

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
