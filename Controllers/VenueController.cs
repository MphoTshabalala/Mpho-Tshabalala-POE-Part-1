using GrootmanEvents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrootmanEvents.Controllers
{
    public class VenueController : Controller
    {
        private readonly GrootmanEventsDbContext _context;

        public VenueController(GrootmanEventsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Venues.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        public GrootmanEventsDbContext Get_context1()
        {
            return _context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Venue venue, ApplicationDbContext _context1)
        {
            if (ModelState.IsValid)
            {
                _context1.Add(venue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(venue);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            return View(venue);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(
            int id,
            Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Update(venue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(venue);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var venue =
                await _context.Venues.FindAsync(id);

            return View(venue);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult>
            DeleteConfirmed(int id)
        {
            var venue =
                await _context.Venues.FindAsync(id);

            _context.Venues.Remove(venue);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}