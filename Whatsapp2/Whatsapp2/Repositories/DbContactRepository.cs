using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsapp2.Models;
using System.Data.Entity;
using Whatsapp2.Models;

namespace Whatsapp2.Repositories
{
    public class DbContactRepository
    {
        private DatabaseEntities db = new DatabaseEntities();

        public void AddContacts(Contacts Contacts)
        {
            db.Contacts.Add(Contacts);
            db.SaveChanges();
        }

        public void DeleteContacts(Contacts Contacts)
        {
            Contacts dbContacts = GetContacts(Contacts.Id);
            if (dbContacts != null)
            {
                db.Contacts.Remove(dbContacts);
                db.SaveChanges();
            }
        }

        public void EditContacts(Contacts Contacts)
        {
            Contacts dbContacts = db.Contacts.SingleOrDefault(c => c.Id == Contacts.Id);
            if (dbContacts != null)
            {
                dbContacts.Name = Contacts.Name;
                dbContacts.Email = Contacts.Email;
                db.SaveChanges();
            }
        }
        
        public IEnumerable<Contacts> GetAllContacts(string email)
        {
            return db.Contacts.Where(c => (c.OwnerEmail == email)).ToList();
        }

        public Contacts GetContacts(int id)
        {
            return db.Contacts.SingleOrDefault(c => c.Id == id);
        }
    }
}