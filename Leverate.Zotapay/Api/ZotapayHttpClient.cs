using System;
using System.Net.Http;
using System.Threading.Tasks;
using Leverate.Zotapay.Infrastructure;
using Leverate.Zotapay.Infrastructure.Serializer;

namespace Leverate.Zotapay.Api
{
    internal class ZotapayHttpClient
    {
        private readonly string m_domain;



        internal ZotapayHttpClient(bool isSandbox)
        {
            m_domain = isSandbox ? "https://sandbox.zotapay.com/" : "https://gate.zotapay.com/";
        }




        internal async Task<TResponse> Get<TResponse, TRequest>(string relativePath, TRequest request)
        {
            return await this.SendRequest<TResponse, TRequest>(relativePath, request, (httpClient, url) => httpClient.GetAsync(url));
        }

        internal async Task<TResponse> Post<TResponse, TRequest>(string relativePath, TRequest request)
        {
            return await this.SendRequest<TResponse, TRequest>(relativePath, request, (httpClient, url) => httpClient.PostAsync(url, null));
        }




        private async Task<TResponse> SendRequest<TResponse, TRequest>(string relativePath, TRequest request,
            Func<HttpClient, string, Task<HttpResponseMessage>> sendingRequestFunc)
        {
            using (var httpClient = new HttpClient())
            {
                var formSerializer = new FormSerializer();

                var url = string.Concat(m_domain, relativePath, formSerializer.Serialize(request));

                var responseMessage = await sendingRequestFunc(httpClient, url);

                responseMessage.EnsureSuccessStatusCode();

                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                var response = formSerializer.Deserialize<TResponse>(responseContent);

                return response;
            }
        }
    }
}
