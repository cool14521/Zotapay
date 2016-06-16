using Leverate.Zotapay.Infrastructure;

namespace Leverate.Zotapay.Contract
{
    public class ReturnCallbackParameters
    {
        [FormParameter("status")]
        public PaymentStatus Status { get; set; }

        [FormParameter("merchant_order")]
        public string MerchantOrderId { get; set; }

        [FormParameter("client_orderid")]
        public string ClientOrderId { get; set; }

        [FormParameter("orderid")]
        public string PaynetOrderId { get; set; }

        [FormParameter("type")]
        public TransactionType TransactionType { get; set; }

        [FormParameter("amount")]
        public decimal Amount { get; set; }

        [FormParameter("descriptor")]
        public string Descriptor { get; set; }

        [FormParameter("error_code")]
        public string ErrorCode { get; set; }

        [FormParameter("error_message")]
        public string ErrorMessage { get; set; }

        [FormParameter("name")]
        public string Name { get; set; }

        [FormParameter("email")]
        public string Email { get; set; }

        [FormParameter("approval-code")]
        public string ApprovalCode { get; set; }

        [FormParameter("last-four-digits")]
        public string LastFourDigits { get; set; }

        [FormParameter("bin")]
        public string Bin { get; set; }

        [FormParameter("card-type")]
        public string CardType { get; set; }

        [FormParameter("gate-partial-reversal")]
        public bool GatePartialReversal { get; set; }

        [FormParameter("gate-partial-capture")]
        public bool GatePartialCapture { get; set; }

        [FormParameter("reason-code")]
        public string ReasonCode { get; set; }

        [FormParameter("processor-rrn")]
        public string ProcessorRrn { get; set; }

        [FormParameter("comment")]
        public string Comment { get; set; }

        [FormParameter("rapida-balance")]
        public decimal RapidaBalance { get; set; }

        [FormParameter("control")]
        public string Control { get; set; }

        [FormParameter("merchantdata")]
        public string MerchantData { get; set; }
    }
}
