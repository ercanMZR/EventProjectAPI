namespace EventProjectWeb.DTO.Event
{
    public class CreateEventRequestDto
    {
        public string Name { get; set; }
        public string DetailedDescription { get; set; }
        public string Address { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
