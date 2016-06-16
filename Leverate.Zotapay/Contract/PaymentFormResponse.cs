using Leverate.Zotapay.Infrastructure;

namespace Leverate.Zotapay.Contract
{
    public class PaymentFormResponse
    {
        [FormParameter("type")]
        public PaymentFormResponseType Type { get; set; }

        [FormParameter("status")]
        public string Status { get; set; }

        [FormParameter("paynet-order-id")]
        public string PaynetOrderId { get; set; }

        [FormParameter("merchant-order-id")]
        public string MerchantOrderId { get; set; }

        [FormParameter("serial-number")]
        public string SerialNumber { get; set; }

        [FormParameter("error-message")]
        public string ErrorMessage { get; set; }

        [FormParameter("error-code")]
        public string ErrorCode { get; set; }

        [FormParameter("redirect-url")]
        public string RedirectUrl { get; set; }
    }
}
