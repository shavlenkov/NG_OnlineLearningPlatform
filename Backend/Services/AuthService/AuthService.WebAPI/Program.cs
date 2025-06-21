using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AuthService.DAL;
using AuthService.DAL.DatabaseContext;
using AuthService.DAL.Initializer;
using AuthService.BLL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddAuthServiceDAL(builder.Configuration);
builder.Services.AddAuthServiceBLL();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    
    try
    {
        var context = serviceProvider.GetRequiredService<AuthServiceDbContext>();
        
        Initializer.InitializeDb(context);
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Error message: {exception.Message}");
        
        throw;
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapControllers();

app.Run();