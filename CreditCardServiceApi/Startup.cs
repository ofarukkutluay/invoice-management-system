using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CreditCardServiceApi.Applications;
using CreditCardServiceApi.Applications.Company.Commands;
using CreditCardServiceApi.Applications.Company.Queries;
using CreditCardServiceApi.Applications.Pay.Commands;
using CreditCardServiceApi.Applications.Pay.Queries;
using CreditCardServiceApi.DataAccess;
using CreditCardServiceApi.DataAccess.Abstracts;

namespace CreditCardServiceApi
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CreditCardServiceApi", Version = "v1" });
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICompanyRepository, MongoDbCompanyDal>();
            services.AddScoped<ICreditCardRepository, MongoDbCreditCardDal>();
            services.AddScoped<IPayRepository, MongoDbPayDal>();

            services.AddScoped<ICommandService<CreateCompanyViewModel>, CreateCompanyCommand>();
            services.AddScoped<IQueryService<IEnumerable<GetCompaniesViewModel>>, GetCompaniesQuery>();
            services.AddScoped<ICommandService<CreatePayViewModel>, CreatePayCommand>();
            services.AddScoped<IQueryService<IEnumerable<GetPaysViewModel>>, GetPaysQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CreditCardServiceApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
