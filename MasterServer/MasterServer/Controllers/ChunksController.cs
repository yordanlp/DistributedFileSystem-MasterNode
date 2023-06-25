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
    public class ChunksController : ControllerBase {
        private readonly AppDbContext _context;

        public ChunksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetChunks/{fileName}")]
        public async Task<ActionResult<IEnumerable<Chunk>>> GetChunks(string fileName)
        {
            return await _context.Chunks.Where(chunk => chunk.File.Name == fileName).ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chunk>> GetChunk(int id)
        {
            var chunk = await _context.Chunks.FindAsync(id);

            if (chunk == null)
            {
                return NotFound();
            }

            return chunk;
        }

        [HttpPost]
        public async Task<ActionResult<Chunk>> PostChunk(Chunk chunk)
        {
            _context.Chunks.Add(chunk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChunk", new { id = chunk.Id }, chunk);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChunk(int id)
        {
            var chunk = await _context.Chunks.FindAsync(id);
            if (chunk == null)
            {
                return NotFound();
            }

            _context.Chunks.Remove(chunk);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
