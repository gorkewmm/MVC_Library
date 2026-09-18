using System.ComponentModel.DataAnnotations;

namespace WebUygulamaProje.Models
{
    public class Kitap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string KitapAdi { get; set; }

        public string Tanim { get; set; }

        [Required]
        public string Yazar { get; set; }

        [Required]
        [Range(50,5000)]
        public double Fiyat { get; set; }
    }
}
