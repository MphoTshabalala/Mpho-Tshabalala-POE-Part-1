using GrootmanEvents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrootmanEvents.Controllers
{
    public class EventController : Controller
    {
        private readonly GrootmanEventsDbContext _context;

        public EventController(GrootmanEventsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(
                await _context.Events.ToListAsync()
            );
        }
    }
}