namespace CreditCard.RestAPI.DataContext.CreditCardMigrations
{
    using CreditCard.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CreditCard.RestAPI.DataContext.CreditCardDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContext\CreditCardMigrations";
        }

        protected override void Seed(CreditCard.RestAPI.DataContext.CreditCardDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var cards = new Card[] {
                new Card { Id = 1, CardNumber = "4111111111111111", ExpiryDate = "012020" }, // Visa
                new Card { Id = 2, CardNumber = "5111111111111111", ExpiryDate = "022027" }, // MasterCard
                new Card { Id = 3, CardNumber = "311111111111111",  ExpiryDate = "032028" },  // Amex
                new Card { Id = 4, CardNumber = "3222222222222222", ExpiryDate = "042029" }, // JCB
                new Card { Id = 5, CardNumber = "6111111111111111", ExpiryDate = "052030" }  // Unknown
            };
            context.Cards.AddOrUpdate(cards);
        }
    }
}
