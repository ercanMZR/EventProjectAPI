namespace EventProjectWeb.Model.ORM
{
    public class Venue :BaseEntity
    {
        public string VenueName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
    }
}
