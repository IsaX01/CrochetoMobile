using CrochetoApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrochetoApi.Controllers
{
    public class CrochetController : Controller
    {
        private readonly AppDbContext _context;

        public CrochetController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("crochet/new")]
        public async Task<IActionResult> Create([FromBody]  Models.Crochet card)
        {
            Debug.WriteLine("Card", card);
            _context.Crochets.Add(card);
            await _context.SaveChangesAsync();
            return Ok(card);
        }

        [HttpGet("crochets")]
        public async Task<ActionResult> GetAll()
        {
            var crochets = await _context.Crochets.ToListAsync();
            return Ok(crochets);
        }

        [HttpPut("crochet/{id}")]
        public async Task<IActionResult> Update(int id, Models.Crochet card)
        {
            if (card.UserId != User.Identity.Name && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            if (id != card.Id)
            {
                return BadRequest();
            }

            _context.Entry(card).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (YourEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("crochet/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!User.IsInRole("Admin"))
            {
                return Forbid();
            }

            var crochet = await _context.Crochets.FindAsync(id);
            if (crochet == null)
            {
                return NotFound();
            }

            _context.Crochets.Remove(crochet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YourEntityExists(int id)
        {
            return _context.Crochets.Any(e => e.Id == id);
        }

    }
}
