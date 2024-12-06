namespace EventProjectWeb.Model.ORM
{
    public class ActivityEventImages:BaseEntity
    {
        public string ImagePath { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
