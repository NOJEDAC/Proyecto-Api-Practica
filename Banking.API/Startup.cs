using AutoMapper;
using Banking.Application.Accounts.Assemblers;
using Banking.Application.Accounts.Contracts;
using Banking.Application.Accounts.Queries;
using Banking.Application.Accounts.Services;
using Banking.Application.Auth.Contracts;
using Banking.Application.Auth.Jwt;
using Banking.Application.Auth.Queries;
using Banking.Application.Auth.Services;
using Banking.Application.Customers.Contracts;
using Banking.Application.Customers.Queries;
using Banking.Application.Customers.Assemblers;
using Banking.Application.Customers.Services; 
using Banking.Application.Users.Assemblers;
using Banking.Application.Users.Contracts;
using Banking.Application.Users.Services;
using Banking.Domain.Accounts.Contracts;
using Banking.Domain.Auth.Contracts;
using Banking.Domain.Customers.Contracts; 
using Banking.Infrastructure.Accounts.Persistence.NHibernate.Repository;
using Banking.Infrastructure.Auth.Hashing;
using Banking.Infrastructure.Customers.Persistence.NHibernate.Repository;
using Banking.Infrastructure.NHibernate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Common;
using System;
using System.Text; 

namespace Banking.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
                services.AddAutoMapper();
                services.AddSingleton(new SessionFactory(Environment.GetEnvironmentVariable("MYSQL_BANKING_CORE")));
                var serviceProvider = services.BuildServiceProvider();
                var mapper = serviceProvider.GetService<IMapper>();
                services.AddSingleton(new NewAccountAssembler(mapper));
                services.AddSingleton(new NewUserAssembler(mapper));
                services.AddSingleton(new NewCustomerAssembler(mapper));
                services.AddSingleton(new Hasher());
                services.AddSingleton(new JwtProvider());
                services.AddScoped<IUnitOfWork, UnitOfWorkNHibernate>(); 
                services.AddScoped<IAccountApplicationService, AccountApplicationService>();
                services.AddScoped<ICustomerApplicationService, CustomerApplicationService>();
                services.AddScoped<IUserApplicationService, UserApplicationService>();
                services.AddScoped<IAuthApplicationService, AuthApplicationService>();

                services.AddTransient<IAccountRepository, AccountNHibernateRepository>((ctx) =>
                {
                    IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                    return new AccountNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
                });
                services.AddTransient<ICustomerRepository, CustomerNHibernateRepository>((ctx) =>
                {
                    IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                    return new CustomerNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
                });
                services.AddTransient<IUserRepository, UserNHibernateRepository>((ctx) =>
                {
                    IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                    return new UserNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
                });
                services.AddSingleton<IAccountQueries, AccountMySQLDapperQueries>();
                services.AddSingleton<ICustomerQueries, CustomerMySQLDapperQueries>();
                services.AddSingleton<IAuthQueries, AuthMySQLDapperQueries>();

                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })
                .AddJwtBearer("JwtBearer", jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY"))),
                            ValidateIssuer = true,
                            ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),

                            ValidateAudience = true,
                            ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),

                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.FromMinutes(double.Parse(Environment.GetEnvironmentVariable("JWT_EXP_MINUTES") ?? "180"))
                        };
                });

                services.AddAuthorization(cfg =>
                {
                    // NOTE: The claim type and value are case-sensitive
                    cfg.AddPolicy("accessCustomers", p => p.RequireClaim("accessCustomers", "true"));
                });

                services.AddCors();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
