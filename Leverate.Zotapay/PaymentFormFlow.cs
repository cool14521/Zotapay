using System.Threading.Tasks;
using Leverate.Zotapay.Api;
using Leverate.Zotapay.Contract;

namespace Leverate.Zotapay
{
    public class PaymentFormFlow
    {
        private readonly ZotapayApi m_api;
        private readonly string m_merchantControl;

        public PaymentFormFlow(string merchantControl)
        {
            m_merchantControl = merchantControl;

            m_api = new ZotapayApi(true);
        }


        public EndpointPaymentFormRequest CreateEndpointPaymentFormRequest()
        {
            return new EndpointPaymentFormRequest(this.m_merchantControl);
        }

        public async Task<PaymentFormResponse> RequestPaymentForm(EndpointPaymentFormRequest request)
        {
            return await m_api.FormTransactionByEndpointId(request);
        }


        public EndpointGroupPaymentFormRequest CreateEndpointGroupPaymentFormRequest()
        {
            return new EndpointGroupPaymentFormRequest(this.m_merchantControl);
        }

        public async Task<PaymentFormResponse> RequestPaymentForm(EndpointGroupPaymentFormRequest request)
        {
            return await m_api.FormTransactionByEndpointId(request);
        }
    }
}
