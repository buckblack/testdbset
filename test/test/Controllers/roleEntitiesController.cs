using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Entity;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class roleEntitiesController : ControllerBase
    {
        private readonly DbTestContext _context;

        public roleEntitiesController(DbTestContext context)
        {
            _context = context;
        }

        // GET: api/roleEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<roleEntity>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }
        public DataSet GetUserChartByTime()
        {
            _context.Database.ExecuteSqlRaw()
            return _context.StatisticalUserViews.FromSqlRaw("select * from role")
        }

        // GET: api/roleEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<roleEntity>> GetroleEntity(int id)
        {
            var roleEntity = await _context.Roles.FindAsync(id);

            if (roleEntity == null)
            {
                return NotFound();
            }

            return roleEntity;
        }

        // PUT: api/roleEntities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutroleEntity(int id, roleEntity roleEntity)
        {
            if (id != roleEntity.id)
            {
                return BadRequest();
            }

            _context.Entry(roleEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roleEntityExists(id))
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

        // POST: api/roleEntities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<roleEntity>> PostroleEntity(roleEntity roleEntity)
        {
            _context.Roles.Add(roleEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetroleEntity", new { id = roleEntity.id }, roleEntity);
        }

        // DELETE: api/roleEntities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<roleEntity>> DeleteroleEntity(int id)
        {
            var roleEntity = await _context.Roles.FindAsync(id);
            if (roleEntity == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(roleEntity);
            await _context.SaveChangesAsync();

            return roleEntity;
        }

        private bool roleEntityExists(int id)
        {
            return _context.Roles.Any(e => e.id == id);
        }
    }
}
