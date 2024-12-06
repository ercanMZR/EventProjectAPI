using System.ComponentModel.DataAnnotations;

namespace EventProjectWeb.Model.ORM
{
    public class City:BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

    }
}
