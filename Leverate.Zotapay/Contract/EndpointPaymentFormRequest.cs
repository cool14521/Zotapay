using System.ComponentModel.DataAnnotations;

namespace Leverate.Zotapay.Contract
{
    public class EndpointPaymentFormRequest : PaymentFormRequest
    {
        internal EndpointPaymentFormRequest(string merchantControl) : base(merchantControl)
        {
        }

        [Required]
        public string EnpointId { get; set; }

        public override string Control
        {
            get
            {
                var secretString = string.Concat(this.EnpointId, this.ClientOrderId, (this.Amount*100).ToString("#"), this.Email, m_merchantControl);
                return this.EncryptUsingSHA1(secretString);
            }
        }
    }
}