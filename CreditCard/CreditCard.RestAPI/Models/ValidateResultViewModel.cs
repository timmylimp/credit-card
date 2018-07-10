using System.ComponentModel;

namespace CreditCard.RestAPI.Models
{
    public class ValidateResultViewModel
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