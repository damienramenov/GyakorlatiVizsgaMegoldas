using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    public class AutoMarka
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Marka { get; set; }

        public Flotta? Flotta { get; set; }
    }
}
