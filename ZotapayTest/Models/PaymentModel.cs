namespace ZotapayTest.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }

        public string OrderId { get; set; }

        public decimal Amount { get; set; }

        public string Status { get; set; }
        
        public string PaynetOrderId { get; set; }
        
        public string TransactionType { get; set; }
        
        public string Descriptor { get; set; }
        
        public string ErrorCode { get; set; }
        
        public string ErrorMessage { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string ApprovalCode { get; set; }
        
        public string LastFourDigits { get; set; }
        
        public string Bin { get; set; }
        
        public string CardType { get; set; }
        
        public bool GatePartialReversal { get; set; }
        
        public bool GatePartialCapture { get; set; }
        
        public string ReasonCode { get; set; }
        
        public string ProcessorRrn { get; set; }
        
        public string Comment { get; set; }
        
        public decimal RapidaBalance { get; set; }
        
        public string Control { get; set; }
        
        public string MerchantData { get; set; }
    }
}