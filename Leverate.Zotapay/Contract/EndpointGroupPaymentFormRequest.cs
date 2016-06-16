using System.ComponentModel.DataAnnotations;

namespace Leverate.Zotapay.Contract
{
    public class EndpointGroupPaymentFormRequest : PaymentFormRequest
    {
        internal EndpointGroupPaymentFormRequest(string merchantControl) : base(merchantControl)
        {
        }



        [Required]
        public string EnpointGroupId { get; set; }

        public override string Control
        {
            get
            {
                var secretString = string.Concat(this.EnpointGroupId, this.ClientOrderId, this.Amount * 100, this.Email, this.m_merchantControl);
                return this.EncryptUsingSHA1(secretString);
            }
        }
    }
}