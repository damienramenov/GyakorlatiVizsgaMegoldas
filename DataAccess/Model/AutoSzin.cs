using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class AutoSzin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Szin { get; set; }

        public Flotta? Flotta { get; set; }
    }
}
