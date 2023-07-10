using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Apollo_Carter.API.BankManager.API.Extensions.Middleware;
using Apollo_Carter.API.BankManager.Application.Handlers;
using Apollo_Carter.API.BankManager.Application.Mappers;
using Apollo_Carter.API.BankManager.Application.Services;
using Apollo_Carter.API.BankManager.Domain.ApolloData;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Events;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Query;
using Apollo_Carter.API.BankManager.Infrastructure.Factories;
using Apollo_Carter.API.BankManager.Infrastructure.Repositories;
using FluentMediator;
using Jaeger;
using Jaeger.Samplers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OpenTracing;
using OpenTracing.Util;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Apollo_Carter.API.BankManager.API
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

            services.AddScoped<IApolloService, ApolloService>();
            services.AddScoped<IBalanceCalculatorService, BalanceCalculatorService>();
            services.AddTransient<IApolloDataRepository, ApolloDataRepository>(); //just as an example, you may use it as .AddScoped
            services.AddSingleton<ApolloDataProfile>();
            services.AddTransient<IApolloDataFactory, EntityFactory>();
            services.AddTransient<IEndOfDayBalanceFactory, EodBalanceEntityFactory>();


            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(config => {
                config.AddProfile(new ApolloDataProfile());
            });



            services.AddScoped<ApolloCommandHandler>();
            services.AddScoped<ApolloEventHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(
                    typeof(CalculateBalanceSummaryQuery).Assembly
                    ));

            services.AddFluentMediator(builder =>
            {
                builder.On<CreateNewApolloCommand>().PipelineAsync().Return<ApolloData, ApolloCommandHandler>((handler, request) => handler.HandleNewTask(request));

                builder.On<ApolloDataCreatedEvent>().PipelineAsync().Call<ApolloEventHandler>((handler, request) => handler.HandleTaskCreatedEvent(request));

                builder.On<DeleteApolloCommand>().PipelineAsync().Call<ApolloCommandHandler>((handler, request) => handler.HandleDeleteTask(request));

                builder.On<TaskDeletedEvent>().PipelineAsync().Call<ApolloEventHandler>((handler, request) => handler.HandleTaskDeletedEvent(request));
            });

            services.AddSingleton(serviceProvider =>
            {
                var serviceName = Assembly.GetEntryAssembly()?.GetName().Name;

                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

                ISampler sampler = new ConstSampler(true);

                ITracer tracer = new Tracer.Builder(serviceName)
                    .WithLoggerFactory(loggerFactory)
                    .WithSampler(sampler)
                    .Build();

                GlobalTracer.Register(tracer);

                return tracer;
            });

            Log.Logger = new LoggerConfiguration().CreateLogger();

            services.AddOpenTracing();

            services.AddOptions();

            services.AddMvc();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Tasks API V1");
            });
        }
    }
}
