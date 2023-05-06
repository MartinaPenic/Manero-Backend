using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entities
{
    public class CreditCardEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public DateTime ExpirationTime { get; set; }

        [Required]
        public string CVV { get; set; }

        [Required]
        [ForeignKey(nameof(UserID))]
        public string UserID { get; set; }

        [Required]
        public UserEntity User { get; set; }

    }
}
