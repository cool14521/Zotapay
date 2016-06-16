using Leverate.Zotapay.Infrastructure;

namespace Leverate.Zotapay.Contract
{
    public class PaymentFormFinalRedirect
    {
        [FormParameter("status")]
        public PaymentStatus Status { get; set; }

        [FormParameter("orderid")]
        public string PaynetOrderId { get; set; }

        [FormParameter("merchant_order")]
        public string MerchantOrderId { get; set; }

        [FormParameter("client_orderid")]
        public string ClientOrderId { get; set; }

        [FormParameter("error_message")]
        public string ErrorMessage { get; set; }

        [FormParameter("control")]
        public string Control { get; set; }

        [FormParameter("descriptor")]
        public string Descriptor { get; set; }

    }
}