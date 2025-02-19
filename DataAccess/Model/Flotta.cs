using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Flotta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MarkaId { get; set; }

        public AutoMarka? Marka { get; set; }

        [Required]
        public int SzinId { get; set; }
        public AutoSzin? Szin { get; set; }

        [Required]
        public int TipusId { get; set; }
        public AutoTipus? Tipus { get; set; }
    }
}
