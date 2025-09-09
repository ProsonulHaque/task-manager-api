using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using task_manager_api;
using task_manager_api.Interfaces;
using task_manager_api.Services;

#region Dependency Injection
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    var bytes = Encoding.UTF8.GetBytes(builder.Configuration["Authentication:IssuerSigningKey"]!);

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(bytes),
        ValidAudience = builder.Configuration["Authentication:ValidAudience"],
        ValidIssuer = builder.Configuration["Authentication:ValidIssuer"]
    };
});
builder.Services.AddDbContextPool<ApplicationDbContext>(options => 
    options
    .UseNpgsql(connectionString: builder.Configuration["ConnectionStrings:DefaultConnection"])
    .UseSnakeCaseNamingConvention());

builder.Services.AddScoped<ITaskService, TaskService>();
#endregion

#region Middleware Configuration
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion