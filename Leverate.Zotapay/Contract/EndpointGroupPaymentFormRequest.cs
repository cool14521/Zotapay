using System.ComponentModel.DataAnnotations;

namespace Leverate.Zotapay.Contract
{
    public class EndpointGroupPaymentFormRequest : PaymentFormRequest
    {
        public EndpointGroupPaymentFormRequest(
            string merchantControl,
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

            : base(merchantControl, clientOrderId, orderDescription, firstName, lastName, address,
                city, state, zip, country, phone, email, amount, currency, ipAddress, redirectUrl)
        {
            this.EndpointGroupId = endpointGroupId;
        }


        [Required]
        public string EndpointGroupId { get; set; }

        public override string Control
        {
            get
            {
                var secretString = string.Concat(this.EndpointGroupId, this.ClientOrderId, this.Amount * 100, this.Email, this.m_merchantControl);
                return this.EncryptUsingSHA1(secretString);
            }
        }
    }
}