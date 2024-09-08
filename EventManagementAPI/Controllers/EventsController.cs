using EventManagementAPI.Data;
using EventManagementAPI.DTOs;
using EventManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.Include(e => e.UserEvents).ThenInclude(ue => ue.User).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _context.Events.Include(e => e.UserEvents).ThenInclude(ue => ue.User).FirstOrDefaultAsync(e => e.Id == id);
            if (@event == null) return NotFound();

            return @event;
        }

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent(EventCreateDTO CreateEventDto)
        {
            var @event = new Event
            {
                Title = CreateEventDto.Title,
                Description = CreateEventDto.Description,
                Location = CreateEventDto.Location,
            };

            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent), new { id = @event.Id }, @event);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, Event @event)
        {
            if (id != @event.Id) return BadRequest();
            _context.Entry(@event).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null) return NotFound();
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
