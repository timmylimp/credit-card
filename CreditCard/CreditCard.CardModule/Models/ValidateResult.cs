using System.ComponentModel;

namespace CreditCard.CardModule.Models
{
    public class ValidateResult
    {
        public Result Result { get; set; }
        public CardType CardType { get; set; }

    }

    public enum Result
    {
        Valid,
        Invalid,
        [Description("Does not exist")]
        DoesNotExist
    }

    public enum CardType
    {
        Visa,
        MasterCard,
        Amex,
        JCB,
        Unknown
    }
}