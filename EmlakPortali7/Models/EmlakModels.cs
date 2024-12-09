using System.ComponentModel.DataAnnotations;

namespace EmlakPortali7.Models
{
    public class EmlakModels
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Location { get; set; }

        public string Image { get; set; }

        public int OwnerId { get; set; }
    
    }
}
