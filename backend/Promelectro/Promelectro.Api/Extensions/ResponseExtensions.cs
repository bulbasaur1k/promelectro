using Microsoft.AspNetCore.Http;

namespace Promelectro.Api.Extensions
{
    public static class ResponseExtensions
    {
        public static void AddApplicationError(this HttpResponse response)
        {
            response.Headers.Add("access-control-expose-headers", "Application-Error");
        }
    }
}