namespace EventProjectWeb.DTO.Event
{
    public class GetEventResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DetailedDescription { get; set; }
        public string Address { get; set; }
        public string GoogleMapLink { get; set; }
    }
}
