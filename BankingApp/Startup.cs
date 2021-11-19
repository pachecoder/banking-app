using BankingApp.Data;
using BankingApp.Domain.Repository;
using BankingApp.Infrastructure.Mapper;
using BankingApp.Repository;
using BankingApp.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

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

            services.AddTransient<ICustomerServices, CustomerServices>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<ITransactionServices, TransactionServices>();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {

            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                            //.WriteTo.MongoDBCapped("mongodb://localhost:27017/logs" )
                            .WriteTo.Console()
                            .WriteTo.File("log.txt")
                            .WriteTo.MSSqlServer(connectionString: "Data Source=.; Initial Catalog=BankDb_Dev; Integrated Security=SSPI;",
                                sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvents", AutoCreateSqlTable = true })
                            .Enrich.WithMachineName()
                            .CreateLogger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();

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
