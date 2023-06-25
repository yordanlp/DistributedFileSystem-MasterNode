using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MasterServer;
using MasterServer.Models;

namespace MasterServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChunkServersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChunkServersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ChunkServers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChunkServer>>> GetChunkServers()
        {
            return await _context.ChunkServers.ToArrayAsync();
        }

        // GET: api/ChunkServers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChunkServer>> GetChunkServer(int id)
        {
            var chunkServer = await _context.ChunkServers.FindAsync(id);

            if (chunkServer == null)
            {
                return NotFound();
            }

            return chunkServer;
        }

        // PUT: api/ChunkServers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChunkServer(int id, ChunkServer chunkServer)
        {
            if (id != chunkServer.Id)
            {
                return BadRequest();
            }

            _context.Entry(chunkServer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChunkServerExists(id))
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

        // POST: api/ChunkServers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChunkServer>> PostChunkServer(ChunkServer chunkServer)
        {
            _context.ChunkServers.Add(chunkServer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChunkServer", new { id = chunkServer.Id }, chunkServer);
        }

        // DELETE: api/ChunkServers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChunkServer(int id)
        {
            var chunkServer = await _context.ChunkServers.FindAsync(id);
            if (chunkServer == null)
            {
                return NotFound();
            }

            _context.ChunkServers.Remove(chunkServer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChunkServerExists(int id)
        {
            return _context.ChunkServers.Any(e => e.Id == id);
        }
    }
}
