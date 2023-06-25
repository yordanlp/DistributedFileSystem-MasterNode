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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChunkServer>>> GetChunkServers()
        {
            return await _context.ChunkServers.ToArrayAsync();
        }

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


        [HttpPost]
        public async Task<ActionResult<ChunkServer>> PostChunkServer(ChunkServer chunkServer)
        {
            _context.ChunkServers.Add(chunkServer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChunkServer", new { id = chunkServer.Id }, chunkServer);
        }

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
    }
}
