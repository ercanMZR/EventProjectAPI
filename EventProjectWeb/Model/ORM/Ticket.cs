using System.ComponentModel.DataAnnotations.Schema;

namespace EventProjectWeb.Model.ORM
{
    public class Ticket:BaseEntity
    {

        public string TicketType { get; set; }
        public decimal Price { get; set; }
        public bool? Availability { get; set; }
        public int? SeatNo { get; set; }
        public DateTime? SaleStartDate { get; set; }
        public DateTime? SaleEndDate { get; set; }
        public int? Quantity { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
