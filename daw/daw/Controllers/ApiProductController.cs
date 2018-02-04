using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using daw.Data;
using daw.Models;
using Microsoft.AspNetCore.Identity;

namespace daw.Controllers
{
    [Produces("application/json")]
    [Route("api/ApiProduct")]
    public class ApiProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApiProductController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
             
        }

        // GET: api/ApiProduct
        [HttpGet]
        public IEnumerable<Product> GetProducts([FromQuery] string search, [FromQuery] bool? tip, [FromQuery] float? note)
        {
            var result = from m in _context.Products select m;
            if (string.IsNullOrEmpty(search) && !tip.HasValue && !note.HasValue)
            {
                return result;
            }
            else if (!string.IsNullOrEmpty(search) && !tip.HasValue) {
                result = from m in _context.Products where m.LocationName.Contains(search) select m;
            }
            else if (!string.IsNullOrEmpty(search) && tip == false)
            {
                result = from m in _context.Products where m.LocationName.Contains(search) && m.Tip == false select m;
            }
            else if (!string.IsNullOrEmpty(search) && tip == true)
            {
                result = from m in _context.Products where m.LocationName.Contains(search) && m.Tip == true select m;
            }
            else if (string.IsNullOrEmpty(search) && tip == false)
            {
                result = from m in _context.Products where m.Tip == false select m;
            }
            else if (string.IsNullOrEmpty(search) && tip == true)
            {
                result = from m in _context.Products where m.Tip == true select m;
            }

            if (note == 1)
            {
                return result.OrderByDescending(x=>x.Note);
            } else
            {
                return result.OrderBy(x => x.Note);
            }
        }

        // GET: api/ApiProduct/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/ApiProduct/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/ApiProduct Wishlist
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] dynamic data)
        {
            int locationId = data.locationId;
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = _context.Users.Single(u => u.Id == userId);

            var check = from m in _context.Wishlist where m.Products.Id == locationId && m.User == user select m;
            var list = check.ToList();
            if (list.Count == 0 )
            {
                var result = _context.Products.First(c => c.Id == locationId);


                var wishlist = new Wishlist
                {
                    User = user,
                    Products = result
                };

                _context.Wishlist.Add(wishlist);

                await _context.SaveChangesAsync();

                return new JsonResult(wishlist);
            }
            else { return new JsonResult(locationId); }
        }

        // DELETE: api/ApiProduct/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}