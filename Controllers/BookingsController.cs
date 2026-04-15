using GrootmanEvents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GrootmanEvents.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LIST BOOKINGS
        public async Task<IActionResult> Index()
        {
            var bookings = _context.Bookings
                .Include(b => b.Venue)
                .Include(b => b.Event);

            return View(await bookings.ToListAsync());
        }

        // CREATE BOOKING (GET)
        public IActionResult Create()
        {
            ViewData["VenueId"] =
                new SelectList(
                    _context.Venues,
                    "VenueId",
                    "VenueName");

            ViewData["EventId"] =
                new SelectList(
                    _context.Events,
                    "EventId",
                    "EventName");

            return View();
        }

        // CREATE BOOKING (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                // CHECK DOUBLE BOOKING
                var conflict = await _context.Bookings.AnyAsync(b =>
                    b.VenueId == booking.VenueId &&
                    booking.StartDate < b.EndDate &&
                    booking.EndDate > b.StartDate);

                if (conflict)
                {
                    ModelState.AddModelError("",
                        "Venue already booked for these dates.");

                    return View(booking);
                }

                _context.Add(booking);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(booking);
        }

        // EDIT BOOKING (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var booking =
                await _context.Bookings.FindAsync(id);

            if (booking == null)
                return NotFound();

            ViewData["VenueId"] =
                new SelectList(
                    _context.Venues,
                    "VenueId",
                    "VenueName",
                    booking.VenueId);

            ViewData["EventId"] =
                new SelectList(
                    _context.Events,
                    "EventId",
                    "EventName",
                    booking.EventId);

            return View(booking);
        }

        // EDIT BOOKING (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
            Edit(int id, Booking booking)
        {
            if (id != booking.BookingId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(booking);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(booking);
        }

        // DELETE BOOKING (GET)
        public async Task<IActionResult>
            Delete(int id)
        {
            var booking =
                await _context.Bookings
                .Include(b => b.Venue)
                .Include(b => b.Event)
                .FirstOrDefaultAsync(
                    m => m.BookingId == id);

            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // DELETE BOOKING (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
            DeleteConfirmed(int id)
        {
            var booking =
                await _context.Bookings
                .FindAsync(id);

            _context.Bookings.Remove(booking);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}