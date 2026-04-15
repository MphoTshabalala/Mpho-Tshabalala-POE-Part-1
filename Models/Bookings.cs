using System.ComponentModel.DataAnnotations;

namespace GrootmanEvents.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public int VenueId { get; set; }

        [Required]
        public int EventId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public Venue Venue { get; set; }

        public Event Event { get; set; }
    }
}