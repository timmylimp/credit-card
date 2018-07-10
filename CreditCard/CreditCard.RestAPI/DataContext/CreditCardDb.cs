using CreditCard.Entities;
using System.Data.Entity;

namespace CreditCard.RestAPI.DataContext
{
    public class CreditCardDb : DbContext
    {
        public CreditCardDb() : base("LocalServer") { }

        public DbSet<Card> Cards { get; set; }

    }
}
