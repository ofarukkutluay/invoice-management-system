namespace WebClient.Models.Payment
{
    public class CreatePayOrderViewModel
    {
        public int InvoiceId { get; set; }
        public int PersonId { get; set; }
        public string CardHolderName { get; set; }
        public long CardNumber { get; set; }
        public int ExpirationMouth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVCCode { get; set; }
        public decimal Amount { get; set; }
    }
}
