using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Hudson.Authenticator.Ioc.Settings
{
    public class GlobalExceptionSetting : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (SqlException ex)
            {
                //var logErroApi = LogErroApi.PreencherObjetoErro(ex.GetType().ToString(), "RND.IB.Autenticacao", ex.Message, ex.Number, context.Request.GetEncodedUrl());
                //await _logErroApiRepositorio.Inserir(logErroApi);

                //_logger.LogError($"Erro inesperado: {ex}");
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                if (!(ex is Win32Exception w32ex))
                    w32ex = ex.InnerException as Win32Exception;

                int statusCode = w32ex != null ? w32ex.ErrorCode : ex.HResult;
                //var logErroApi = LogErroApi.PreencherObjetoErro(ex.GetType().ToString(), "RND.IB.Autenticacao", ex.Message, statusCode, context.Request.GetEncodedUrl());
                //await _logErroApiRepositorio.Inserir(logErroApi);

                //_logger.LogError($"Erro inesperado: {ex}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            const int statusCode = StatusCodes.Status500InternalServerError;

            var json = JsonConvert.SerializeObject(new
            {
                statusCode,
                message = "Ocorreu um erro no processamento da requisição",
                detailed = exception
            });

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(json);
        }
    }
}
