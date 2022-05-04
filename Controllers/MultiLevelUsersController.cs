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
    public class MultiLevelUsersController : ControllerBase
    {
        private readonly UserDBContext _context;

        public MultiLevelUsersController(UserDBContext context)
        {
            _context = context;
        }

        // GET: api/MultiLevelUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MultiLevelUser>>> GetMultiLevelUsers()
        {
            return await _context.MultiLevelUsers.ToListAsync();
        }

        // GET: api/MultiLevelUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MultiLevelUser>> GetMultiLevelUser(Guid id)
        {
            var multiLevelUser = await _context.MultiLevelUsers.FindAsync(id);

            if (multiLevelUser == null)
            {
                return NotFound();
            }

            return multiLevelUser;
        }

        // PUT: api/MultiLevelUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMultiLevelUser(Guid id, MultiLevelUser multiLevelUser)
        {
            if (id != multiLevelUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(multiLevelUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultiLevelUserExists(id))
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

        // POST: api/MultiLevelUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MultiLevelUser>> PostMultiLevelUser(MultiLevelUser multiLevelUser)
        {
            _context.MultiLevelUsers.Add(multiLevelUser);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetMultiLevelUser", new { id = multiLevelUser.Id }, multiLevelUser);
            return new JsonResult("Added Successfully");
        }

        // DELETE: api/MultiLevelUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMultiLevelUser(Guid id)
        {
            var multiLevelUser = await _context.MultiLevelUsers.FindAsync(id);
            if (multiLevelUser == null)
            {
                return NotFound();
            }

            _context.MultiLevelUsers.Remove(multiLevelUser);
            await _context.SaveChangesAsync();

            //return NoContent();
            return new JsonResult("Deleted Successfully");
        }

        private bool MultiLevelUserExists(Guid id)
        {
            return _context.MultiLevelUsers.Any(e => e.Id == id);
        }
    }
}
