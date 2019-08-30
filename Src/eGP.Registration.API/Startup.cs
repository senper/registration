using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using eGP.Abstraction.Application.Behaviors;
using eGP.Registration.Application.Organization.Commands;
using eGP.Registration.Application.Organization.Repository;
using eGP.Registration.Application.Organization.Validations;
using eGP.Registration.Domain.Organization;
using eGP.Registration.Persistance.Contexts;
using eGP.Registration.Persistance.Repositories;
using eGP.Registration.Persistance.Repositories.Organization;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Microsoft.OpenApi.Models;
using IContainer = Autofac.IContainer;

namespace eGP.Registration.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMediator, Mediator>();
            services.AddMediatR(typeof(RegisterOrganizationCommand).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            
            var connectionString = Configuration.GetConnectionString("eGPRegistrationApiConection");
            services.AddEntityFrameworkNpgsql().AddDbContext<RegistrationDbContext>(opt =>
            opt.UseNpgsql(connectionString));

           
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddSingleton(_ => connectionString);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // Uncomment this to enable Attribute validation 
                //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(typeof(RegisterOrganizationValidator)));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("0.0.1", new OpenApiInfo
                {
                    Title = "eGP.Oranization.Api",
                    Version = "0.0.1",
                    Description = "API for Organization and Personnel registration and management",
                    Contact = new OpenApiContact
                    {
                        Name = "",
                        Email = String.Empty,
                        Url = new Uri("https://twitter.com/spboyer")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under Perago",
                        Url = new Uri("https://example.com/license"),
                    },

                });
            });

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new MediatorModule());

            return new AutofacServiceProvider(container.Build());
        }


        //private static IMediator BuildMediator(IServiceCollection services)
        //{
        //    var builder = new ContainerBuilder();
        //    builder.RegisterType<OrganizationRepository>().As<IOrganizationRepository>();
        //    Container = builder.Build();
           
        //    services.AddScoped<ServiceFactory>(p => p.GetService);

        //    //Pipeline
        //    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));



        //    var provider = services.BuildServiceProvider();

        //    return provider.GetRequiredService<IMediator>();
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/0.0.1/swagger.json", "eGP Oranization API v001");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
