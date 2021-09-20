using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using POSEIDON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace POSEIDON
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
      services.AddCors();

      services.AddControllers().AddJsonOptions(opt =>
      {
        //Para convertir el String del request en Integner (Enum)
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
      });

      //Uso la base de datos SQL SERVER Poseidon
      services.AddDbContext<PoseidonContext>(options =>
         options.UseSqlServer(Configuration.GetConnectionString
              ("SQLServerConnection")));

      //Seguridad
      services.AddAuthentication(o => {
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
                    .AddJwtBearer(cfg =>
                    {
                      cfg.Audience = Configuration["Tokens:Audience"];
                      cfg.ClaimsIssuer = Configuration["Tokens:Issuer"];
                      cfg.TokenValidationParameters = new TokenValidationParameters()
                      {
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = Configuration["Tokens:Audience"],
                        //Se valida la llave de cifrado
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                        //Se validara el tiempo de vida del token
                        ValidateLifetime = true
                      };
                    });

      //Habilitar CORS
      services.AddCors();

      //Configuro swagger
      services.AddSwaggerGen(c =>
      {
        // Publicacion Doc
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api POSEIDON REST", Version = "v1" });

        //Incluimos que vamos a utilizar tokens
        c.AddSecurityDefinition("Bearer",
          new OpenApiSecurityScheme
            {
              Description = "JWT Authorization (bearer)",
              Type = SecuritySchemeType.Http,
              Scheme = "bearer"
            });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference
              {
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme
              }
            },
            new List<string>()
          }
        });
      });

      //Indico al MVC que vamos a usar autenticacion
      services.AddMvc(options =>
      {
        //Agregamos una politica para indicar que todos nuestros servicios 
        //requieren que los usuarios hayan iniciado sesióm
        var policy = new AuthorizationPolicyBuilder()
          .RequireAuthenticatedUser()
          .Build();
        options.Filters.Add(new AuthorizeFilter(policy));
      });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      //Habilitar CORS
      var urlAcepted = Configuration.GetSection("AllowedHosts").Value.Split(",");
      app.UseCors(builder =>
        builder.WithOrigins(urlAcepted)
                     .AllowAnyHeader()
                     .AllowAnyMethod());

      //Habilitar swagger
      app.UseSwagger();

      //indica la ruta para generar la configuración de swagger
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Caduca REST");
        c.RoutePrefix = string.Empty;
      });

      app.UseHttpsRedirection();

      app.UseRouting();

      //Uso Autenticacion y Autorizacion
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
