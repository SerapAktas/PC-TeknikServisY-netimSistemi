using PC_Servis.DAL;
using PC_Servis.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Servis.BLL.Repository
{
    public class MessageRepo : RepositoryBase<Message, long>
    {
        public MessageRepo()
        {
            return;
            try
            {
                MyContext db = new MyContext();
                db.Messages.Add(new Message()
                {
                    Level = -5,
                    SendBy = "46f0cc49-62d0-4ffc-9a96-af5f9a5da0ae",
                    SentTo = "46f0cc49-62d0-4ffc-9a96-af5f9a5da0ae"
                });
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
