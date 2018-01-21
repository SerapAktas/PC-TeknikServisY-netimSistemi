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
    [Table("Operatörler")]

    public class Operatör
    {
        [Key]
        public string ID { get; set; }
        public string UserID { get; set; }
        public string TeknisyenID { get; set; }

        [Required]
        public int ArizaID { get; set; }
        public bool OnayladiMi { get; set; } = false;

        [ForeignKey("ArizaID")]
        public virtual Ariza Ariza { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("TeknisyenID")]
        public virtual Teknisyen Teknisyen { get; set; }
    }
}
