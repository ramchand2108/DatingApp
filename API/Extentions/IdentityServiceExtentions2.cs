using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Extentions
{
    public static class IdentityServiceExtentions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration _config){
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(Options => {
                Options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"])),
                    ValidateIssuer = false ,
                    ValidateAudience = false
                };
            });
            return services;
        }
    }
}