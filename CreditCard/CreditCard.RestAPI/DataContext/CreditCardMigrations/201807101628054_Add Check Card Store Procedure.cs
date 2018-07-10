namespace CreditCard.RestAPI.DataContext.CreditCardMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCheckCardStoreProcedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.CheckCreditCard",
                 p => new
                 {
                     CardNumber = p.String(maxLength: 16),
                     ExpiryDate = p.String(maxLength: 6),
                 },
                body:
                    @"SELECT COUNT(*) FROM
                    (
	                    SELECT TOP(1) *
	                    FROM [dbo].[Cards]
	                    WHERE CardNumber = @CardNumber AND ExpiryDate = @ExpiryDate
                    ) AS c"
            );
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.CheckCreditCard");
        }
    }
}
