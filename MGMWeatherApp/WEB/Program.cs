using Business.Abstract;
using Business.Concrete;
using Data.Abstract;
using Data.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IStadiumService, StadiumManager>();
builder.Services.AddTransient<IStationService, StationManager>();
builder.Services.AddTransient<IFihristService, FihristManager>();
builder.Services.AddTransient<IStadiumMeasuringService, StadiumMeasuringManager>();

builder.Services.AddTransient<IStadiumDal, EfStadiumDal>();
builder.Services.AddTransient<IStadiumMeasuringDal, EfStadiumMeasuringDal>();
builder.Services.AddTransient<IFihristDal, EfFihristDal>();
builder.Services.AddTransient<IStationDal, EfStationDal>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
     
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
