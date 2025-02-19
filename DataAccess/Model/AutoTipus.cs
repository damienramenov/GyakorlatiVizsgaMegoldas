using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class AutoTipus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Tipus { get; set; }

        public Flotta? Flotta { get; set; }

        public override string ToString() => Tipus;
    }
}
