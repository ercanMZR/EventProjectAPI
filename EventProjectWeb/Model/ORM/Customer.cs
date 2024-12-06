namespace EventProjectWeb.Model.ORM
{
    public class Customer:BaseEntity
    {
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
