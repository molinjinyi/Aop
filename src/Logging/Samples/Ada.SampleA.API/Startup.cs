using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ada.SampleA.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public class AuthResponsesOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var authAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                    .Union(context.MethodInfo.GetCustomAttributes(true))
                    .OfType<AuthorizeAttribute>();

                if (authAttributes.Any())
                    operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
            }
        }
        public class AutoRestSchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                var type = context.Type;
                if (type.IsEnum)
                {
                    schema.Extensions.Add(
                        "x-ms-enum",
                        new OpenApiObject
                        {
                            ["name"] = new OpenApiString(type.Name),
                            ["modelAsString"] = new OpenApiBoolean(true)
                        }
                    );
                };
            }
        }

        public class SwaggerEnumFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema model, SchemaFilterContext context)
            {
                if (context.Type.IsEnum)
                {
                    var values = Enum.GetValues(context.Type);
                    var valuesArr = new OpenApiArray();
                    foreach (var value in values)
                    {
                        var item = new OpenApiObject
                        {
                            ["name"] = new OpenApiString(Enum.GetName(context.Type, value)),
                            ["value"] = new OpenApiString(value.ToString())
                        };

                        valuesArr.Add(item);
                    }
                    model.Extensions.Add("x-ms-enum", new OpenApiObject
                    {
                        ["name"] = new OpenApiString(context.Type.Name),
                        ["modelAsString"] = new OpenApiBoolean(true),
                        ["values"] = valuesArr
                    });
                }

            }
        }
        public class ErrorResponsesOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {

                operation.Responses.Add("500", new OpenApiResponse { Description = "Error" });
            }
        }
        // ApiExplorerGroupPerVersionConvention.cs
        public class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
        {
            public void Apply(ControllerModel controller)
            {
                var controllerNamespace = controller.ControllerType.Namespace; // e.g. "Controllers.V1"
                var apiVersion = controllerNamespace.Split('.').Last().ToLower();

                controller.ApiExplorer.GroupName = apiVersion;
            }
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API - V1", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "My API - V2", Version = "v2" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Ada.SampleA.API.xml");
                c.IncludeXmlComments(filePath);
                c.OperationFilter<AuthResponsesOperationFilter>();
                c.OperationFilter<ErrorResponsesOperationFilter>();
                c.SchemaFilter<SwaggerEnumFilter>();
                c.EnableAnnotations();
            }); 
            services.AddMvc(c =>
         c.Conventions.Add(new ApiExplorerGroupPerVersionConvention())
     );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "V2 Docs");
            });
            app.UseRouting();
            app.UseApiVersioning();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
