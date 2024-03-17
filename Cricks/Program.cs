using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Cricks.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

// Create a WebApplication builder with the arguments passed to the program
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add the DbContext and configure it to use SQLite with the connection string from the configuration
builder.Services.AddDbContext<CricksDataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity services to the DI container and configure it to use the DbContext for storage
builder.Services.AddIdentity<IdentityUser, IdentityRole>() // Add IdentityRole here
    .AddEntityFrameworkStores<CricksDataContext>()
    .AddDefaultTokenProviders(); // Add this to add the default token providers


// Add JWT authentication services to the DI container and configure it
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Add controllers to the DI container
builder.Services.AddControllers();

// Add API explorer services to the DI container
builder.Services.AddEndpointsApiExplorer();

// Add Swagger services to the DI container and configure it
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Cricks API", Version = "v1" });

    // Add JWT authentication to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.

// Use Swagger in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use HTTPS redirection middleware
app.UseHttpsRedirection();

// Use authentication middleware
app.UseAuthentication();

// Use authorization middleware
app.UseAuthorization();

// Map controller routes
app.MapControllers();

// Create roles and default users
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await DbInitializer.InitializeAsync(userManager, roleManager);
}


// Run the application
app.Run();
