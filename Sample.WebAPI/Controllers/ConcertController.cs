using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample.DTO.Models;
using Sample.RestHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WebAPI.Controllers
{
    [Authorize(Roles = "AppUser, Administrator")]
    [Route("api/Concert")]
    public class ConcertController : Controller
    {
        private static Guid Id1 = Guid.NewGuid();

        private static Guid Id2 = Guid.NewGuid();

        public static List<Guid> Ids = new List<Guid>
        {
            Id1,
            Id2  
        };

        private static List<Concert> concerts = new List<Concert>
        {
            new Concert
            {
                Id = Id1,
                Name = "elso"
            },
            new Concert
            {
                Id = Id2,
                Name = "masodik"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Concert>>> GetConcertsAsync()
        {
            foreach (var concert in concerts)
            {
                concert.RestMetas.Add(new RestMeta { Method = "GetConcertDetails", Ref = $"https://localhost:5001/api/Concert/{concert.Id}" });
            }

            return concerts;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Concert>> GetConcertByIdAsync(Guid Id)
        {
            return concerts.Where(c => c.Id.Equals(Id))
                           .SingleOrDefault();
        }

        [HttpPost("{appUserId}")]
        public async Task<ActionResult<Concert>> CreateConcertAsync(Guid appUserId, [FromBody]Concert concert)
        {
            Guid id = Guid.NewGuid();
            Ids.Add(id);

            Concert newConcert = new Concert
            {
                Id = id,
                AppUserId = appUserId,
                Name = "Új"
            };

            concerts.Add(newConcert);

            return CreatedAtAction(nameof(GetConcertByIdAsync), new { id = newConcert.Id }, newConcert);
        }
    }
}
