
using Microsoft.EntityFrameworkCore;
using IM.Core.Infra.Repos;
using IM.Repo.DBContext;
using IM.Repo;
using IM.bll.Services;
using IM.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IMDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IMemberSkillService, MemberSkillService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICityService, CityService>();

builder.Services.AddScoped<IMemberRepo, MemberRepo>();
builder.Services.AddScoped<IMemberSkillRepo, MemberSkillRepo>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); 

app.Run();
