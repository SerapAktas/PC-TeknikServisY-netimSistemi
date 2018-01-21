using Microsoft.AspNet.Identity.EntityFramework;
using PC_Servis.Entity.Entities;
using PC_Servis.Entity.IdentityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Servis.DAL
{
    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext()
            : base("name=MyCon")
        { }

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Ariza> Arizalar { get; set; }
        public virtual DbSet<ArizaDurum> ArizaDurumlar { get; set; }
        public virtual DbSet<ArizaRapor> ArizaRaporlar { get; set; }
        public virtual DbSet<Operatör> Operatörler { get; set; }
        public virtual DbSet<Fotograf> Fotograflar { get; set; }
        public virtual DbSet<Teknisyen> Teknisyenler { get; set; }

    }

}
