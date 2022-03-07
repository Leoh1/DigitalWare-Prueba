using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using AutoMapper;

using Framework.Transversal.Mapper;
using Framework.Transversal.Common;
using Framework.InfraStructure.Data;
using Framework.InfraStructure.Repository;
using Framework.InfraStructure.Interface;
using Framework.Domain.Interface;
using Framework.Domain.Core;
using Framework.Application.Interface;
using Framework.Application.Main;
using System.Reflection;
using Framework.Services.WebApi.Helpers;

//using Swashbuckle.AspNetCore.Swagger;

using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Framework.Transversal.Logging;
using Newtonsoft.Json.Serialization;

namespace Framework.Services.WebApi
{
    public class Startup
    {
        readonly string myPolicy = "policyApiGlobus";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin()
                );
            });

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });

            //services.AddControllers();
            services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

            var appSettingsSection = Configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);

            //configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();

            //Se especifican la vida �til de los servicios.
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            //Se usa de Scoped o de �mbito porque necesitamos que se instancie una vez por solicitud
            services.AddScoped<IClienteApplication, ClienteApplication>();
            services.AddScoped<IClienteDomain, ClienteDomain>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IDetalleApplication, DetalleApplication>();
            services.AddScoped<IDetalleDomain, DetalleDomain>();
            services.AddScoped<IDetalleRepository, DetalleRepository>();

            services.AddScoped<IProductoApplication, ProductoApplication>();
            services.AddScoped<IProductoDomain, ProductoDomain>();
            services.AddScoped<IProductoRepository, ProductoRepository>();

            services.AddScoped<IFacturaApplication, FacturaApplication>();
            services.AddScoped<IFacturaDomain, FacturaDomain>();
            services.AddScoped<IFacturaRepository, FacturaRepository>();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));


            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var IsSuer = appSettings.IsSuer;
            var Audience = appSettings.Audience;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var userId = int.Parse(context.Principal.Identity.Name);
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = IsSuer,
                        ValidateAudience = true,
                        ValidAudience = Audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ////Configuraci�n Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });

            app.UseRouting();

            app.UseCors(myPolicy);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
