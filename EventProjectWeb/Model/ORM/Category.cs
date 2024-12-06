using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventProjectWeb.Model.ORM
{
    public class Category: BaseEntity
    {
        public string Name { get; set; } = String.Empty;


        public int? EventId { get; set; }
        [ForeignKey("EventId")]

        public Event Event { get; set; }
    }
}
