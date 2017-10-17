using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whatsapp2.Models;
using Whatsapp2.Repositories;
using Whatsapp2.Models;

namespace Whatsapp2.Controllers
{

    public class ContactsController : Controller
    {
        private DbContactRepository ContactsRepository = new DbContactRepository();
        private DbChatMessageRepository chatRepository = new DbChatMessageRepository();

        public ActionResult Index()
        {
            Accounts Accounts = (Accounts)Session["loggedin_Accounts"];
            IEnumerable<Contacts> allContacts = ContactsRepository.GetAllContacts(Accounts.Email);
            return View(allContacts);
        }


        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(Contacts Contacts)
        {
            if (ModelState.IsValid)
            {
                Accounts account = (Accounts)Session["loggedin_Accounts"];
                Contacts.OwnerEmail = account.Email;
                ContactsRepository.AddContacts(Contacts);

                return RedirectToAction("Index");
            }

            return View(Contacts);
        }


        public ActionResult EditContact(int id)
        {
            return View(ContactsRepository.GetContacts(id));
        }

        [HttpPost]
        public ActionResult EditContact(Contacts Contacts)
        {
            if (ModelState.IsValid)
            {
                ContactsRepository.EditContacts(Contacts);

                return RedirectToAction("Index");
            }

            return View(Contacts);
        }


        public ActionResult DeleteContact(int id)
        {
            return View(ContactsRepository.GetContacts(id));
        }

        [HttpPost]
        public ActionResult DeleteContact(Contacts Contacts)
        {
            if (ModelState.IsValid)
            {
                ContactsRepository.DeleteContacts(Contacts);

                return RedirectToAction("Index");
            }

            return View(Contacts);
        }

        public ActionResult GetAll()
        {
            return View();
        }

        public ActionResult AddMessage(int id)
        {
            Accounts senderAccounts = (Accounts)Session["loggedin_Accounts"];
            ChatMessages mess = new ChatMessages();
            mess.SenderEmail = senderAccounts.Email;
            Contacts recieverAccounts = ContactsRepository.GetContacts(id);
            mess.RecieverEmail = recieverAccounts.Email;
            ViewBag.Title = recieverAccounts.Name;
            return View(mess);
        }

        [HttpPost]
        public ActionResult AddMessage(ChatMessages mess)
        {
            if (ModelState.IsValid)
            {
                chatRepository.AddChatMessages(mess);

            }
            return RedirectToAction("Index");
        }
    }
}