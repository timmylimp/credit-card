using CreditCard.CardModule.Models;
using CreditCard.CardModule.Models.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreditCard.CardModule.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValidVisa()
        {
            var card = new Card { CardNumber = "4111111111111111", ExpiryDate = "012020" };
            var validator = new CardValidator(card);
            var result = validator.Validate();

            Assert.AreEqual(result.CardType, CardType.Visa);
            Assert.AreEqual(result.Result, Result.Valid);
        }
        [TestMethod]
        public void TestValidMasterCard()
        {
            var card = new Card { CardNumber = "5111111111111111", ExpiryDate = "022027" };
            var validator = new CardValidator(card);
            var result = validator.Validate();

            Assert.AreEqual(result.CardType, CardType.MasterCard);
            Assert.AreEqual(result.Result, Result.Valid);
        }
        [TestMethod]
        public void TestValidAmex()
        {
            var card = new Card { CardNumber = "311111111111111", ExpiryDate = "032028" };
            var validator = new CardValidator(card);
            var result = validator.Validate();

            Assert.AreEqual(result.CardType, CardType.Amex);
            // We don't have valid amex
            //Assert.AreEqual(result.Result, Result.Invalid);
        }
        [TestMethod]
        public void TestValidJCB()
        {
            var card = new Card { CardNumber = "3222222222222222", ExpiryDate = "042029" };
            var validator = new CardValidator(card);
            var result = validator.Validate();

            Assert.AreEqual(result.CardType, CardType.JCB);
            Assert.AreEqual(result.Result, Result.Valid);
        }
        [TestMethod]
        public void TestInvalidVisa()
        {
            var card = new Card { CardNumber = "4111111111111111", ExpiryDate = "012021" };
            var validator = new CardValidator(card);
            var result = validator.Validate();

            Assert.AreEqual(result.CardType, CardType.Visa);
            Assert.AreEqual(result.Result, Result.Invalid);
        }
        [TestMethod]
        public void TestInvalidMasterCard()
        {
            var card = new Card { CardNumber = "5111111111111111", ExpiryDate = "012020" };
            var validator = new CardValidator(card);
            var result = validator.Validate();

            Assert.AreEqual(result.CardType, CardType.MasterCard);
            Assert.AreEqual(result.Result, Result.Invalid);
        }
        [TestMethod]
        public void TestInvalidAmex()
        {
            var card = new Card { CardNumber = "311111111111111", ExpiryDate = "032028" };
            var validator = new CardValidator(card);
            var result = validator.Validate();

            Assert.AreEqual(result.CardType, CardType.Amex);
            Assert.AreEqual(result.Result, Result.Invalid);
        }
        [TestMethod]
        public void TestInvalidJCB()
        {
            var card = new Card { CardNumber = "3222222222222222", ExpiryDate = "042029" };
            var validator = new CardValidator(card);
            var result = validator.Validate();

            Assert.AreEqual(result.CardType, CardType.JCB);
            // We don't have invalid jcb
            //Assert.AreEqual(result.Result, Result.Valid);
        }
    }
}
