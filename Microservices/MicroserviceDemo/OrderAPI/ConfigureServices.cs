using System.Net;
using Polly;
using Polly.Extensions.Http;

namespace OrderAPI;

public static class ConfigureServices
{
    public static IHttpClientBuilder AddCircuitBreakerPolicy(this IHttpClientBuilder builder)
    {
        return builder.AddPolicyHandler(GetPolicy());
    }

    private static IAsyncPolicy<HttpResponseMessage> GetPolicy()
    {
        return HttpPolicyExtensions.HandleTransientHttpError()
            .OrResult(response => response.StatusCode == HttpStatusCode.InternalServerError)
            .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30));
    }
}