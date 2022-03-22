using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Zave.Torbat.Siman.Model.DbContexts;
using Zave.Torbat.Siman.Model.Models1.Factory;
using Zave.Torbat.Siman.Model.Models1.Terminal;
using Zave.Torbat.Siman.Model.Repositories;
using Zave.Torbat.Siman.Server.Hubs;
using Zave.Torbat.Siman.Server.Model;
using Zave.Torbat.Siman.Server.Services;
using Zave.Torbat.Siman.Server.SmsService;

namespace Zave.Torbat.Siman.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors(options =>
                options.AddPolicy("Cors", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
            //services.AddMvc();
            services.AddDbContext<DB_FactoryContext>();//opt => opt.UseSqlServer(Configuration.GetConnectionString("UserDbConnection")));
            services.AddDbContext<DB_TerminalContext>();//opt => opt.UseSqlServer(Configuration.GetConnectionString("UserDbConnection")));
            //services.AddDbContext<IDataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UserDbConnection")));
            services.AddScoped<IDataContext>(sp => sp.GetService<DB_FactoryContext>());
            services.AddScoped<IDataContext>(sp => sp.GetService<DB_TerminalContext>());

            //services.AddIdentity<TTruck, IdentityRole>().AddEntityFrameworkStores<DB_FactoryContext>();
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is a secret phrase"));
            //var asymSigningKey=new AsymmetricSignatureProvider(signingKey,SecurityAlgorithms.RsaSha256);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = signingKey,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddSignalR();
            services.AddHttpContextAccessor();
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
            services.AddScoped(typeof(ApplicationSignInManager));
            services.AddScoped(typeof(DriversRepository));//.AddScoped<GenericRepository<>>();
             services.AddScoped(typeof(BarRepository));
            services.AddScoped(typeof(InputBarRepository));
            services.AddScoped(typeof(TerminalRepository));
            services.AddScoped(typeof(TruckRepository));
            services.AddScoped(typeof(TruckTurnRepository));
            services.AddScoped(typeof(TruckTypeRepository));
            services.AddScoped(typeof(NewTerminalRepository));
            services.AddScoped<ITakeLoadTimeoutService, TakeLoadTimeoutService>();
            services.AddScoped<IConfirmationService, ConfirmationService>();
            services.AddScoped<IServerSmsService, ServerSmsService>();
            services.AddScoped<ISmsService, SmsService.SmsService>();
            services.AddScoped<IFarazSendSms, FarazSendSms>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseCors("Cors");
            app.UseMvc();
            app.UseSignalR(routes =>
            {
                routes.MapHub<PositionHub>("/positionHub");
            });
        }
    }
}
