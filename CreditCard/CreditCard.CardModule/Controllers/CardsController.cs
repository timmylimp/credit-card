using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCard.CardModule.DataContext;
using CreditCard.CardModule.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CreditCard.CardModule.Models.Validator;
using CreditCard.CardModule.Extensions;

namespace CreditCard.CardModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private CreditCardDb db;

        public CardsController(CreditCardDb db) { this.db = db; }

        [HttpGet]
        public IEnumerable<Card> Get()
        {
            return db.Cards;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = db.Cards.SingleOrDefault(b => b.Id == id);
            if (result == null)
                return NotFound(result);

            return Ok(result);

        }

        [HttpPost]
        public IActionResult Post([FromBody]Card card)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Cards.Add(card);
            db.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Card card)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != card.Id)
                return BadRequest();

            try
            {
                db.Cards.Update(card);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                return NotFound("Id not found");
            }

            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = db.Cards.SingleOrDefault(b => b.Id == id);
            if (result == null)
                return NotFound("Id not found");
            
            db.Cards.Remove(result);
            db.SaveChanges();
            return Ok("Deleted");
        }

        [HttpPost("validate")]
        public IActionResult ValidateCard([FromBody] Card card)
        {
            var validator = new CardValidator(card);

            var result = validator.Validate();

            if (result.Result == Result.Valid)
            {
                if (!db.Cards.Any(p => p.CardNumber == card.CardNumber && p.ExpiryDate == card.ExpiryDate))
                    result.Result = Result.DoesNotExist;
            }
            return Ok(new { result = result.Result.ToFriendlyString(), cardType = result.CardType.ToFriendlyString() });
        }

    }
}