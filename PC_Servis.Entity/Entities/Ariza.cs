using PC_Servis.Entity.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Servis.Entity.Entities
{
    [Table("Arizalar")]

    public class Ariza 
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        [Required]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        [Required]
        [Display(Name = "Konum")]
        public string Konum { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
       
        public virtual List<Fotograf> Fotograflar { get; set; } = new List<Fotograf>();
        public virtual List<ArizaDurum> ArizaDurumlar { get; set; } = new List<ArizaDurum>();

    }
}
