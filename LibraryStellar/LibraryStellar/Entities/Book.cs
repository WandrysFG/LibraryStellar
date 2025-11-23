using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryStellar.Entities
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Author { get; set; }

        [Range(0, 2100)]
        public int Year { get; set; }
    }
}
