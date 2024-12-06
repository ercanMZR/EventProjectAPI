using System.ComponentModel.DataAnnotations.Schema;

namespace EventProjectWeb.Model.ORM
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public string DetailedDescription { get; set; }
        public string? Address { get; set; }
        public string? GoogleMapLink { get; set; }

        [ForeignKey("CityId")]
        public int? CityId { get; set; }
        public City City { get; set; }
        [ForeignKey("ArtistId")]
        public int? ArtistId { get; set; }
        public Artist Artist { get; set; }
        [ForeignKey("TicketId")]
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public List<ActivityEventImages> Activities { get; set; } = new();
    }
}
