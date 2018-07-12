using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditCard.CardModule.Migrations
{
    public partial class CreateSpCheckCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF OBJECT_ID('dbo.SP_CHECK_CREDIT_CARD ', 'P') IS NOT NULL  
    DROP PROCEDURE dbo.SP_CHECK_CREDIT_CARD;  
GO
CREATE PROCEDURE dbo.SP_CHECK_CREDIT_CARD 
	@CardNumber nvarchar(16), 
	@ExpiryDate nvarchar(6),
	@Found int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @Found = COUNT(*) FROM
	(
		SELECT TOP(1) *
		FROM [dbo].[Cards]
		WHERE CardNumber = @CardNumber AND ExpiryDate = @ExpiryDate
	) AS Found
END
GO
"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF OBJECT_ID('dbo.SP_CHECK_CREDIT_CARD ', 'P') IS NOT NULL  
    DROP PROCEDURE dbo.SP_CHECK_CREDIT_CARD;  
GO
"
            );
        }
    }
}
