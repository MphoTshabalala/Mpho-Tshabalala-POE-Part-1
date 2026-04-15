using System.ComponentModel.DataAnnotations;

namespace GrootmanEvents.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}