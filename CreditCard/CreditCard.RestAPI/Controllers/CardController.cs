using CreditCard.Entities;
using CreditCard.RestAPI.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreditCard.RestAPI.Controllers
{
    public class CardController : ApiController
    {
        private CreditCardDb db = new CreditCardDb();
        // GET api/card
        public IEnumerable<Card> Get()
        {
            return db.Cards.ToList();
        }

        // GET api/card/5
        public Card Get(int id)
        {
            return db.Cards.FirstOrDefault(p => p.Id == id);
        }

        // POST api/card
        public void Post([FromBody]Card value)
        {
            db.Cards.Add(value);
            db.SaveChanges();
        }

        // PUT api/card/5
        public void Put(int id, [FromBody]Card value)
        {
            var toUpdate = db.Cards.SingleOrDefault(p => p.Id == id);
            if (toUpdate != null)
            {
                toUpdate.ExpiryDate = value.ExpiryDate;
                toUpdate.CardNumber = value.CardNumber;
                db.SaveChanges();
            }
        }

        // DELETE api/card/5
        public void Delete(int id)
        {
            var toDelete = db.Cards.SingleOrDefault(p => p.Id == id);
            if (toDelete != null)
                db.Cards.Remove(toDelete);
        }
    }
}
