using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsapp2.Models;
using Whatsapp2.Models;

namespace Whatsapp2.Repositories
{
    public class DbChatMessageRepository
    {
        private DatabaseEntities db = new DatabaseEntities();

        public void AddChatMessages(ChatMessages ChatMessages)
        {
            db.ChatMessages.Add(ChatMessages);
            db.SaveChanges();
            
        }

        //public ChatMessagess GetLastChatMessages(string email)
        //{
          //  var countOfRows = db.ChatMessagess.Count();
           // return db.ChatMessagess.OrderBy(c => 1 == 1).Skip(countOfRows - 1).FirstOrDefault();

            //return (from c in ctx.ChatMessages
            //        where c.RecieverAccId == recieverId &&
            //      c.SenderAccId == senderId ||
            //    c.SenderAccId == recieverId
            //  select c);
      //  }

        //public IEnumerable<ChatMessagess> GetAllChatMessagess(string email)
        //{
          //  return (from c in db.ChatMessagess
            //        where c.RecieverEmail == email
              //      select c).ToList();
        //}

        public IEnumerable<ChatMessages> GetLastChatMessages(string email)
        {
            return (from c in db.ChatMessages
                    where c.RecieverEmail == email ||
                    c.SenderEmail == email
                    select c).ToList();
        }
    }
}