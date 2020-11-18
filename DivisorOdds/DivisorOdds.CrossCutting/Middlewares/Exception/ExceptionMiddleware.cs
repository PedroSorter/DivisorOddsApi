using DivisorOdds.CrossCutting.DefaultResponses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;

namespace DivisorOdds.CrossCutting.Middlewares
{
    [ExcludeFromCodeCoverage]
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));

            this._next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            LogException(context, exception);

            return ExceptionResult(context, exception);
        }

        private void LogException(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, MontarInnerExceptionMessage(exception, true));
        }

        private Task ExceptionResult(HttpContext context, Exception exception)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError;

            var genericResult = new GenericResult()
            {
                success = false,
                message = "Ocorreu um erro inesperado no servidor, tente novamente mais tarde",
                data = exception.Message
            };

            var result = JsonConvert.SerializeObject(genericResult);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }

        private string MontarInnerExceptionMessage(Exception exception, bool primeiro)
        {
            if (exception == null)
                return string.Empty;
            var texto = primeiro ? "Message:" : "InnerException";

            return $"{texto} {exception.Message}{Environment.NewLine}{MontarInnerExceptionMessage(exception.InnerException, false)}";

        }
    }

    public static class FormatterPipelineExtensions
    {
        public static IApplicationBuilder UseException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}

