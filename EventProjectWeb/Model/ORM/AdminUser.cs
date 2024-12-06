namespace EventProjectWeb.Model.ORM
{
    public class AdminUser:BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }    
    }
}
