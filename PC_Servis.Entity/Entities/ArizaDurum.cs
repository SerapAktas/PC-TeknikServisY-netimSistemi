using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Servis.Entity.Entities
{
    [Table("ArizaDurumlar")]

    public class ArizaDurum 
    {
        [Key]
        public string ID { get; set; }
        public int ArizaID { get; set; }
        public string TeknisyenID { get; set; }
        [Required]
        public bool GarantiKapsamindaMi { get; set; } = false;
        public bool ArizaGiderildiMi { get; set; } = false;
        public DateTime TamamlanmaZamani { get; set; } = default(DateTime);
        [Required]
        public string Aciklama { get; set; }

        [ForeignKey("ArizaID")]
        public virtual Ariza Ariza { get; set; }
        [ForeignKey("TeknisyenID")]
        public virtual Teknisyen Teknisyen { get; set; }
    }

}
