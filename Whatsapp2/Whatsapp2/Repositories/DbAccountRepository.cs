using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsapp2.Models;
using Whatsapp2.Models;

namespace Whatsapp2.Repositories
{
    public class DbAccountRepository
    {
        private DatabaseEntities db = new DatabaseEntities();

        public void AddAccounts(RegisterModel reg)
        {
            Accounts acc = new Accounts();
            acc.Name = reg.Name;
            acc.Email = reg.Email;
            acc.Password = reg.Password;
            db.Accounts.Add(acc);
            db.SaveChanges();
        }

        public Accounts GetAccounts(string email, string password)
        {
            Accounts acc = db.Accounts.SingleOrDefault(c => c.Email == email && c.Password == password);
            return acc;
        }
    }
}