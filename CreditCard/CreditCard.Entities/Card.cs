using System.ComponentModel.DataAnnotations;

namespace CreditCard.Entities
{
    public class Card
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(16)]
        [MinLength(15)]
        public string CardNumber { get; set; }
        [Required]
        [MaxLength(6)]
        public string ExpiryDate { get; set; }
    }
}
