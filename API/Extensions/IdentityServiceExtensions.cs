using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
         public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config ){
                         services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
            return services;
         }
    }
}


// public static class ApplicationServiceExtensions
//     {
//         public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config ) {
//                         services.AddScoped<ITokenService, TokenService>();
//             services.AddDbContext<DataContext>(options =>
//             {
//                 options.UseSqlite(config.GetConnectionString("DefaultConnection"));
//             }
//             );
//             return services;
//         }
//     }
// }