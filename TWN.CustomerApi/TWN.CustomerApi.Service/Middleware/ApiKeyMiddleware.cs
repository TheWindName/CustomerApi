using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace TWN.CustomerApi.Service.Middleware
{
    /// <summary>
    /// Api Key Middleware which allow us has got an authentication method 
    /// in the API Service.
    /// This API KEY will provide us a code in header http when somebody request us data.
    /// </summary>
    public class ApiKeyMiddleware
    {
        #region Private Properties
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "ApiKey";
        #endregion Private Properties

        #region Constructors
        /// <summary>
        /// Principal Constructor
        /// </summary>
        /// <param name="next"></param>
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion Constructors

        #region Public Functions
        /// <summary>
        /// Invoke Method by middleware net core architecture
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided. Using ApiKeyMiddleware) ");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(APIKEYNAME);

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client. (Using ApiKeyMiddleware)");
                return;
            }
            await _next(context);
        }
        #endregion Public Functions
    }
}