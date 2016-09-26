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


        public EndpointPaymentFormRequest CreateEndpointPaymentFormRequest(
            string endpointId,
            string clientOrderId,
            string orderDescription,
            string firstName,
            string lastName,
            string address,
            string city,
            string state,
            string zip,
            string country,
            string phone,
            string email,
            decimal amount,
            string currency,
            string ipAddress,
            string redirectUrl)
        {
            return new EndpointPaymentFormRequest(this.m_merchantControl, endpointId, clientOrderId, orderDescription,
                firstName, lastName, address, city, state, zip, country, phone, email, amount, currency, ipAddress, redirectUrl);
        }

        public async Task<PaymentFormResponse> RequestPaymentForm(EndpointPaymentFormRequest request)
        {
            return await m_api.FormTransactionByEndpointId(request);
        }


        public EndpointGroupPaymentFormRequest CreateEndpointGroupPaymentFormRequest(
            string endpointGroupId,
            string clientOrderId,
            string orderDescription,
            string firstName,
            string lastName,
            string address,
            string city,
            string state,
            string zip,
            string country,
            string phone,
            string email,
            decimal amount,
            string currency,
            string ipAddress,
            string redirectUrl)
        {
            return new EndpointGroupPaymentFormRequest(this.m_merchantControl, endpointGroupId, clientOrderId, orderDescription,
                firstName, lastName, address, city, state, zip, country, phone, email, amount, currency, ipAddress, redirectUrl);
        }

        public async Task<PaymentFormResponse> RequestPaymentForm(EndpointGroupPaymentFormRequest request)
        {
            return await m_api.FormTransactionByEndpointId(request);
        }
    }
}
