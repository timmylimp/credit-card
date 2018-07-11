using CreditCard.Entities;
using CreditCard.RestAPI.DataContext;
using CreditCard.RestAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCard.RestAPI.Models.Validator
{
    public class CardValidator
    {
        public Card Card { get; set; }
        public CardType CardType
        {
            get
            {
                if (Card == null)
                    return CardType.Unknown;
                else if (Card.CardNumber.StartsWith("4") && Card.CardNumber.Length == 16)
                    return CardType.Visa;
                else if (Card.CardNumber.StartsWith("5") && Card.CardNumber.Length == 16)
                    return CardType.MasterCard;
                else if (Card.CardNumber.StartsWith("3") && Card.CardNumber.Length == 15)
                    return CardType.Amex;
                else if (Card.CardNumber.StartsWith("3") && Card.CardNumber.Length == 16)
                    return CardType.JCB;
                else
                    return CardType.Unknown;
            }
        }

        public CardValidator(Card Card)
        {
            this.Card = Card;
        }
        
        public ValidateResultViewModel Validate()
        {
            var result = new ValidateResultViewModel() { CardType = CardType, Result = Result.Invalid };

            int cardYear = 0;
            if (!Int32.TryParse(Card.ExpiryDate.Substring(2), out cardYear))
                return result;
            
            if (result.CardType == CardType.Visa && DateTime.IsLeapYear(cardYear))
                result.Result = Result.Valid;
            else if (result.CardType == CardType.MasterCard && MathUtils.IsPrimeNumber(cardYear))
                result.Result = Result.Valid;
            else if (result.CardType == CardType.JCB)
                result.Result = Result.Valid;

            return result;
        }
    }
}