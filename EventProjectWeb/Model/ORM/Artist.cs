namespace EventProjectWeb.Model.ORM
{
    public class Artist:BaseEntity
    {
        public string ArtistName { get; set; }
        public string? Bio { get; set; }
        public string? ImageURL { get; set; }
    }
}
