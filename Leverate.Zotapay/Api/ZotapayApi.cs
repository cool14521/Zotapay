using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leverate.Zotapay.Contract;

namespace Leverate.Zotapay.Api
{
    internal class ZotapayApi
    {
        private readonly ZotapayHttpClient m_httpClient;


        internal ZotapayApi(bool isSandbox)
        {
            m_httpClient = new ZotapayHttpClient(isSandbox);
        }


        internal async Task<PaymentFormResponse> FormTransactionByEndpointId(EndpointPaymentFormRequest request)
        {
            var relativeUrl = string.Format("paynet/api/v2/sale-form/{0}", request.EndpointId);

            return await m_httpClient.Post<PaymentFormResponse, PaymentFormRequest>(relativeUrl, request);
        }


        internal async Task<PaymentFormResponse> FormTransactionByEndpointId(EndpointGroupPaymentFormRequest request)
        {
            var relativeUrl = string.Format("paynet/api/v2/transfer-form/group/{0}", request.EndpointGroupId);

            return await m_httpClient.Post<PaymentFormResponse, PaymentFormRequest>(relativeUrl, request);
        }
    }
}
