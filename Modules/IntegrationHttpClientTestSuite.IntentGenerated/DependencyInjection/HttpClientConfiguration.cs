using System;
using IntegrationHttpClientTestSuite.IntentGenerated.ClientContracts.InvoiceProxy;
using IntegrationHttpClientTestSuite.IntentGenerated.HttpClients;
using Intent.RoslynWeaver.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Integration.HttpClients.HttpClientConfiguration", Version = "1.0")]

namespace IntegrationHttpClientTestSuite.IntentGenerated.DependencyInjection
{
    public static class HttpClientConfiguration
    {
        public static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAccessTokenManagement(options =>
            {
                configuration.GetSection("IdentityClients").Bind(options.Client.Clients);
            }).ConfigureBackchannelHttpClient();

            services.AddHttpClient<IInvoiceProxyClient, InvoiceProxyHttpClient>(http =>
            {
                http.BaseAddress = configuration.GetValue<Uri>("HttpClients:InvoiceProxy:Uri");
                http.Timeout = configuration.GetValue<TimeSpan?>("HttpClients:InvoiceProxy:Timeout") ?? TimeSpan.FromSeconds(100);
            }).AddClientAccessTokenHandler(configuration.GetValue<string>("HttpClients:InvoiceProxy:IdentityClientKey") ?? "default");
        }
    }
}