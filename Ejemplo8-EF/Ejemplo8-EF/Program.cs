using Ejemplo8_EF.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Authorization a nivel configuracion general
//options =>
//{
//    options.Filters.Add(new AuthorizeFilter(
//        new AuthorizationPolicyBuilder()
//            .RequireAuthenticatedUser()
//            .Build()
//    ));
//}

builder.Services.AddDbContext<UserDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddDefaultIdentity<IdentityUser>(options =>
    {
        //Password
        //options.Password.RequiredLength = 8;
        //options.Password.RequireDigit = true;
        //options.Password.RequireLowercase = true;
        //options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        //options.Password.RequiredUniqueChars = 1;

        //SignIn
        options.SignIn.RequireConfirmedAccount = false;
        //options.SignIn.RequireConfirmedEmail = true;
        //options.SignIn.RequireConfirmedPhoneNumber = false;

        //User
        //options.User.RequireUniqueEmail = true;

        //Bloqueo
        //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
        //options.Lockout.MaxFailedAccessAttempts = 5;
        //options.Lockout.AllowedForNewUsers = true;

    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>();

builder.Services.ConfigureApplicationCookie(o =>
{
    o.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    o.SlidingExpiration = true;
    o.LoginPath = "/Identity/Account/Login";
    o.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();
app.Run();
