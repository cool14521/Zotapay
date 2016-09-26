using System.ComponentModel.DataAnnotations;

namespace Leverate.Zotapay.Contract
{
    public class EndpointPaymentFormRequest : PaymentFormRequest
    {
        public EndpointPaymentFormRequest(
            string merchantControl,
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

            : base(merchantControl, clientOrderId, orderDescription, firstName, lastName, address,
                city, state, zip, country, phone, email, amount, currency, ipAddress, redirectUrl)
        {
            this.EndpointId = endpointId;
        }

        [Required]
        public string EndpointId { get; set; }

        public override string Control
        {
            get
            {
                var secretString = string.Concat(this.EndpointId, this.ClientOrderId, (this.Amount*100).ToString("#"), this.Email, m_merchantControl);
                return this.EncryptUsingSHA1(secretString);
            }
        }
    }
}