using System;
using System.Collections.Generic;
using System.Linq;
using CreditCard.CardModule.DataContext;
using CreditCard.CardModule.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CreditCard.CardModule.Models.Validator;
using CreditCard.CardModule.Extensions;
using Microsoft.EntityFrameworkCore;

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
                // This use SP_CHECK_CREDIT_CARD to check card exists in database
                var searchResult = db.Cards.FromSql("dbo.SP_CHECK_CREDIT_CARD @CardNumber={0}, @ExpiryDate={1}",
                                                        card.CardNumber,
                                                        card.ExpiryDate)
                                           .AsNoTracking()
                                           .ToList();
                if (searchResult.Count <= 0)
                    result.Result = Result.DoesNotExist;

                // This use LINQ to check card exists in database
                //if (!db.Cards.Any(p => p.CardNumber == card.CardNumber && p.ExpiryDate == card.ExpiryDate))
                //    result.Result = Result.DoesNotExist;
            }
            return Ok(new { result = result.Result.ToFriendlyString(), cardType = result.CardType.ToFriendlyString() });
        }

    }
}