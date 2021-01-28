using System.ComponentModel.DataAnnotations;

namespace ElvisApi.Database.Entities
{
    public abstract class Statement : BaseEntity
    {
        [Key]
        public  int Id { get; set; }
        [Required]
        public string Img { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string Phone { get; set; }

    }
}