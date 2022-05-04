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
    public class UserSubCategoriesController : ControllerBase
    {
        private readonly UserDBContext _context;

        public UserSubCategoriesController(UserDBContext context)
        {
            _context = context;
        }

        // GET: api/UserSubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSubCategory>>> GetUserSubCategories()
        {
            return await _context.UserSubCategories.ToListAsync();
        }

        // GET: api/UserSubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSubCategory>> GetUserSubCategory(Guid id)
        {
            var userSubCategory = await _context.UserSubCategories.FindAsync(id);

            if (userSubCategory == null)
            {
                return NotFound();
            }

            return userSubCategory;
        }

        // PUT: api/UserSubCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSubCategory(Guid id, UserSubCategory userSubCategory)
        {
            if (id != userSubCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(userSubCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSubCategoryExists(id))
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

        // POST: api/UserSubCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserSubCategory>> PostUserSubCategory(UserSubCategory userSubCategory)
        {
            _context.UserSubCategories.Add(userSubCategory);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUserSubCategory", new { id = userSubCategory.Id }, userSubCategory);
            return new JsonResult("Added Successfully");
        }

        // DELETE: api/UserSubCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSubCategory(Guid id)
        {
            var userSubCategory = await _context.UserSubCategories.FindAsync(id);
            if (userSubCategory == null)
            {
                return NotFound();
            }

            _context.UserSubCategories.Remove(userSubCategory);
            await _context.SaveChangesAsync();

            //return NoContent();
            return new JsonResult("Deleted Successfully");
        }

        private bool UserSubCategoryExists(Guid id)
        {
            return _context.UserSubCategories.Any(e => e.Id == id);
        }
    }
}
