using CreditCard.CardModule.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CreditCard.CardModule.DataContext
{
    public class CreditCardDb : DbContext
    {
        public CreditCardDb(DbContextOptions<CreditCardDb> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }

        public void EnsureSeed()
        {
            if (!Cards.Any())
            {
                var cards = new Card[] {
                    new Card { CardNumber = "4111111111111111", ExpiryDate = "012020" }, // Visa
                    new Card { CardNumber = "5111111111111111", ExpiryDate = "022027" }, // MasterCard
                    new Card { CardNumber = "311111111111111",  ExpiryDate = "032028" }, // Amex
                    new Card { CardNumber = "3222222222222222", ExpiryDate = "042029" }, // JCB
                    new Card { CardNumber = "6111111111111111", ExpiryDate = "052030" }  // Unknown
                };
                Cards.AddRange(cards);
                SaveChanges();
            }
        }
    }
}
