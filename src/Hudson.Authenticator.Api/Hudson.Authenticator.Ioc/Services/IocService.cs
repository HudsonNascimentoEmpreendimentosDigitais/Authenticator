using Hudson.Authenticator.Ioc.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hudson.Authenticator.Ioc.Services
{
    public static class IocService
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            #region Handlers
            //services.AddTransient<AutenticacaoHandler>();
            //services.AddTransient<IdentificacaoHandler>();
            //services.AddTransient<UsuarioExternoHandler>();
            #endregion

            #region Services            
            //services.AddScoped<HttpHelper, HttpHelper>();
            //services.AddTransient<ITokenAcessoServico, TokenAcessoServico>();
            //services.AddTransient<ITokenServico, TokenServico>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient<IIdentificacaoServico, IdentificacaoServico>();
            #endregion

            #region Repositories
            //services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            //services.AddTransient<ILogErroApiRepositorio, LogErroApiRepositorio>();
            #endregion

            #region Swagger
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerSetting>();
            #endregion

            #region Global Exception
            services.AddTransient<GlobalExceptionSetting>();
            #endregion

            return services;
        }
        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();

            //app.UseSwaggerUI(
            //    options =>
            //    {
            //        foreach (var description in provider.ApiVersionDescriptions)
            //        {
            //            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            //        }
            //    });

            return app;
        }
        public static IApplicationBuilder UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionSetting>();
            return app;
        }
    }
}

