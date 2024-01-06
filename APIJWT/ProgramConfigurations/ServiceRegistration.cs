using APIJWT.Business.Profiles;
using APIJWT.Business.Services.Implementations;
using APIJWT.Business.Services.Interfaces;
using APIJWT.Core.Models;
using APIJWT.Core.Repositories.Interfaces;
using APIJWT.Data.DAL;
using APIJWT.Data.Repositories.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace APIJWT.ProgramConfigurations
{
    public static class ServiceRegistration
    {
        public static void ConfigureService(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            
            services.AddDbContext<ApiDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("default"));
            });
            //Repository registration 
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IPortfolioImageRepository, PortfolioImageRepository>();
            services.AddScoped<IWorkerRepository, WorkerRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IProfessionRepository, ProfessionRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();


            //Service registration 
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPortfolioService, PortfolioService>();
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProfessionService, ProfessionService>();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireDigit = true;

            }).AddEntityFrameworkStores<ApiDbContext>().
                AddDefaultTokenProviders();
            services.AddEndpointsApiExplorer();
            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration.GetSection("JWT:Issuer").Value,
                    ValidAudience = configuration.GetSection("JWT:Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("JWT:Key").Value)),
                    LifetimeValidator = (_, expires, token, _) => token is not null ? expires > DateTime.UtcNow : false,

                };
            });
            services.AddAuthorization();
           
          
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                      {
                            new OpenApiSecurityScheme
                       {
                      Reference = new OpenApiReference
                     {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                     }
                  },
                  new string[]{}
                         }
                     });
            });
        }
    }
}
