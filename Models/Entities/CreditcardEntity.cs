namespace WebApi.Models.Entities
{
    public class CreditcardEntity
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationTime { get; set; }
        public string CVV { get; set; }

    }
}
