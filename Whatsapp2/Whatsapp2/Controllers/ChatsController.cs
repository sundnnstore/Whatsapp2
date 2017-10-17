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
    public class ChatsController : Controller
    {
        private DbChatMessageRepository chatRepository = new DbChatMessageRepository();

        public ActionResult Index()
        {
            Accounts account = (Accounts)Session["loggedin_Accounts"];
            return View(chatRepository.GetLastChatMessages(account.Email));
        }
    }
}