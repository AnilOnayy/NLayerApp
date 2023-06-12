using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NLayer.Repository;
using NLayer.Service.Filters;
using NLayer.Service.Mapping;
using NLayer.Service.Validation;
using NLayer.Web.Modules;
using NLayer.Web.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidatior>());


// Add Auto Mapper
builder.Services.AddAutoMapper(typeof(MapProfile));




builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    })
);


builder.Services.AddHttpClient<ProductApiServices>(
    opt =>
    {
        opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
    }
);

builder.Services.AddHttpClient<CategoryApiService>(
    opt =>
    {
        opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
    }
);


// Autofac Added
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new RepoServiceModule());
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
