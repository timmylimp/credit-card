using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditCard.CardModule.Models
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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