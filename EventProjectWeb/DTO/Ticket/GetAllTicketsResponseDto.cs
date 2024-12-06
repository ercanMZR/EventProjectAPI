namespace EventProjectWeb.DTO.Ticket
{
    public class GetAllTicketsResponseDto
    {
        public string TicketType { get; set; }
        public decimal Price { get; set; }
        public bool? Availability { get; set; }
        public int? SeatNo { get; set; }
    }
}
