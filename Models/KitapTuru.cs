using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUygulamaProje.Models
{
    public class KitapTuru
    {
        [Key]      //PK
        public int Id { get; set; }

        [Required(ErrorMessage ="Kitap Türü adı boş bırakılamaz!")] //not null   
        [MaxLength(25)]
        [DisplayName("Kitap Türü Adı")]
        public string Ad { get; set; }
    }
}