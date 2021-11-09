using AutoMapper;
using BankingApp.Data;
using BankingApp.Infrastructure.Behaviours;
using BankingApp.Infrastructure.Mapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Text.Json.Serialization;

namespace BankingApp
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddControllers();
            //    .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddMediatR(typeof(Startup).Assembly);
            services.AddSwagger();
            services.AddAutoMapper(typeof(DomainProfile).Assembly);

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContext")));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseErrorHandling();
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Awesome Bank");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
