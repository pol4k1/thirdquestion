using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Remoting.Contexts;
using System.Xml.Linq;

namespace ArabaKiralamaUygulamasi.Models
{
    public class Araba
    {
        [Key]
        public int ArabaID { get; set; }

        [Required(ErrorMessage = "Model field is required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Manufacturer field is required")]
        public string Uretici { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Year of Manufacture must be a number")]
        [Display(Name = "Year of production")]
        public int UretimYili { get; set; }

        public string Foto { get; set; }

        public virtual ICollection<Musteri> Musteriler { get; set; }
    }

    public class Musteri
    {
        [Key]
        public int MusteriID { get; set; }

        [Required(ErrorMessage = "Namespace is required")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Age field is required")]
        [Range(18, 70, ErrorMessage = "Age must be between 18 and 70")]
        public int Yas { get; set; }

        [Required(ErrorMessage = "Passport Number field is required")]
        public string PasaportNo { get; set; }

        public virtual ICollection<Araba> Arabalar { get; set; }
    }

    public class ArabaKiralamaContext : DbContext
    {
        public DbSet<Araba> Arabalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
    }
}