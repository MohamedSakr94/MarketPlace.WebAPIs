using MarketPlace.BL;
using MarketPlace.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

#region Default
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region AspIdentity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<MarketContext>();

#endregion

#region Authentication

builder.Services
.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JWT";
})
.AddJwtBearer("JWT", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = Helpers.SecretKeyBuilder(builder.Configuration),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
#endregion

#region Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ManagerPolicy",
p => p.RequireClaim(ClaimTypes.Role, "Manager", "Admin"));
});

#endregion

#region Database
var CS = builder.Configuration.GetConnectionString("MarketPlace");
builder.Services.AddDbContext<MarketContext>(options => options.UseSqlServer(CS));
#endregion

#region Repos
builder.Services.AddScoped<IProductsRepo, ProductsRepo>();
builder.Services.AddScoped<ICategoriesRepo, CategoriesRepo>();
builder.Services.AddScoped<IProducts_CategoriesRepo, Products_CategoriesRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ICartItemRepo, CartItemRepo>();
#endregion

#region UnitOWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region managers
builder.Services.AddScoped<IProductsManager, ProductsManager>();
builder.Services.AddScoped<ICategoriesManager, CategoriesManager>();
builder.Services.AddScoped<IProducts_CategoriesManager, Products_CategoriesManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<ICartItemsManager, CartItemsManager>();
#endregion

#region CORS

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
