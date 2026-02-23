using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AyakkabiTur.Models
{
    public class AyakkabiTuru
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ayakkabı Türü Boş Bırakılamaz!")]
        [MaxLength(25)]
        [DisplayName("Ayakkabı Türü Adı")]
        public string Ad { get; set; }
    }
}
