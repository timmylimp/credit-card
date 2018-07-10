namespace CreditCard.RestAPI.DataContext.CreditCardMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExpiryDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "ExpiryDate", c => c.String(nullable: false, maxLength: 6));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "ExpiryDate");
        }
    }
}
