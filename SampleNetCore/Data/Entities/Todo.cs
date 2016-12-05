using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title{ get; set; }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
