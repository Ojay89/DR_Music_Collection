using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DR_Music_Collection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestMusicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicContollerMemoryDBController : ControllerBase
    {

        private MusicRecordsDBContext _context;
        private MusicRecords mr1 = new MusicRecords(1, "Test", "Test", "Test","Test", 320, 2020);

        public MusicContollerMemoryDBController(MusicRecordsDBContext context)
        {
            _context = context;
        }

        // GET: api/MusicContollerMemoryDB
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicRecords>>> GetInMemoryMusicRecords()
        {
            //PostMusicRecord(new MusicRecords(1, "Test", "Test", "Test", "Test", 320, 2020));
            return await _context.InMemoryMusicRecords.ToListAsync();
        }

        // GET: api/MusicContollerMemoryDB/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicRecords>> GetInMemoryRecord(int id)
        {
            var musicRecords = await _context.InMemoryMusicRecords.FindAsync(id);
            if (musicRecords == null)
            {
                return NotFound();
            }

            return musicRecords;

        }

        // POST: api/MusicContollerMemoryDB
        [HttpPost]
        public async Task<ActionResult<MusicRecords>> PostMusicRecord (MusicRecords musicRecords)
        {
            _context.InMemoryMusicRecords.Add(musicRecords);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInMemoryRecord", new {id = musicRecords.Id}, musicRecords);
        }

        // PUT: api/MusicContollerMemoryDB/5
        [HttpPut("{id}")]
        public async Task <IActionResult> PutMusicRecord(int id, MusicRecords musicRecords)
        {
            if (id != musicRecords.Id)
            {
                return BadRequest();
            }

            _context.Entry(musicRecords).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicRecordsExists(id))
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MusicRecords>> DeleteMusicRecord(int id)
        {
            var musicRecords = await _context.InMemoryMusicRecords.FindAsync(id);
            if (musicRecords == null)
            {
                return NotFound();
            }

            _context.InMemoryMusicRecords.Remove(musicRecords);
            await _context.SaveChangesAsync();

            return musicRecords;
        }
        private bool MusicRecordsExists(int id)
        {
            return _context.InMemoryMusicRecords.Any(i => i.Id == id);
        }
    }
}
