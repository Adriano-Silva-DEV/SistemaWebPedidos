using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SistemaWebPedidos.Api.Configurations;
using SistemaWebPedidos.Api.Extensions;
using SistemaWebPedidos.Application.Interfaces;
using SistemaWebPedidos.Application.Notificacoes;
using SistemaWebPedidos.Application.Services;
using SistemaWebPedidos.Core.Interfaces.Repositories;
using SistemaWebPedidos.Infrastructure.Persistence;
using SistemaWebPedidos.Infrastructure.Persistence.Repository;
using System;
using System.IO;
using System.Text.Json.Serialization;

namespace SistemaWebPedido.Api
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
            services.AddScoped<ApiDbContext>();
            services.AddScoped<IFornecedorService,FornecedorService>();
            services.AddScoped<IProdutoRepository,ProdutoRepository>();
            services.AddScoped<IProdutoService,ProdutoService>();
            services.AddScoped<ICategoriaService,CategoriaService>();
            services.AddScoped<IUsuarioService,UsuarioService>();
            services.AddScoped<IFornecedorRepository,FornecedorRepository>();
            services.AddScoped<ICategoriaRepository,CategoriaRepository>();
            services.AddScoped<ISobreRepository,SobreRepository>();
            services.AddScoped<IUsuarioRepository,UsuarioRepository>();
            services.AddScoped<ISobreService,SobreService>();
            services.AddScoped<INotificador,Notificador>();
            services.AddScoped<IUser,AspNetUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddIdentityConfiguration(Configuration);
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers().AddJsonOptions(x =>
              x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });   


            services.AddControllers(ops => ops.UseDateOnlyTimeOnlyStringConverters())
            .AddJsonOptions(ops => ops.UseDateOnlyTimeOnlyStringConverters());

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaWebPedido.Api", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            }
                );
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaWebPedido.Api v1"));
            }

            app.UseCors("Development");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
