using Microsoft.EntityFrameworkCore;
using ThursdayMarket.DataAccess.Data;
using ThursdayMarket.DataAccess.IRepository.CategoryRepository;
using ThursdayMarket.DataAccess.IRepository.ProductRepository;
using ThursdayMarket.DataAccess.Repository.CategoryRepository;
using ThursdayMarket.DataAccess.Repository.ProductRepository;
using ThursdayMarket.DataAccess.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>(); // Add this line
builder.Services.AddScoped<IProductService, ProductService>(); // Add this line
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
