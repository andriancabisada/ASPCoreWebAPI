#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamCRUD.Data;
using ExamCRUD.Models;

namespace ExamCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCategoriesController : ControllerBase
    {
        private readonly UserDBContext _context;

        public UserCategoriesController(UserDBContext context)
        {
            _context = context;
        }

        // GET: api/UserCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCategory>>> GetUserCategories()
        {
            return await _context.UserCategories.ToListAsync();
        }

        // GET: api/UserCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCategory>> GetUserCategory(Guid id)
        {
            var userCategory = await _context.UserCategories.FindAsync(id);

            if (userCategory == null)
            {
                return NotFound();
            }

            return userCategory;
        }

        // PUT: api/UserCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCategory(Guid id, UserCategory userCategory)
        {
            if (id != userCategory.id)
            {
                return BadRequest();
            }

            _context.Entry(userCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("Updated Successfully");
        }

        // POST: api/UserCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCategory>> PostUserCategory(UserCategory userCategory)
        {
            _context.UserCategories.Add(userCategory);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUserCategory", new { id = userCategory.id }, userCategory);
            return new JsonResult("Added Successfully");
        }

        // DELETE: api/UserCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCategory(Guid id)
        {
            var userCategory = await _context.UserCategories.FindAsync(id);
            if (userCategory == null)
            {
                return NotFound();
            }

            _context.UserCategories.Remove(userCategory);
            await _context.SaveChangesAsync();

            return new JsonResult("Deleted Successfully");
        }

        private bool UserCategoryExists(Guid id)
        {
            return _context.UserCategories.Any(e => e.id == id);
        }
    }
}
