using ProftaakASP.App_DAL;
using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProftaakASP.Controllers
{
    public class MessageController : Controller
    {
        MessageRepository mr = new MessageRepository(new MessageSQLContext());
        AccountRepository ar = new AccountRepository(new AccountSQLContext());
        ViewModelCreateMessage viewmodel = new ViewModelCreateMessage();

        // GET: Message
        public ActionResult Index()
        {
            List<Message> messages = mr.GetAllMessages();
            return View(messages);
        }

        // GET: Message
        public ActionResult IndexReceiver()
        {
            int receiver = Convert.ToInt32(Session["AccountID"]);
            List<Message> messages = mr.GetAllMessagesByReceiver(receiver);
            return View(messages);
        }

        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            Message message = mr.GetMessageById(id);
            if (message != null)
            {
                message.IsRead = true;
                mr.UpdateIsReadStatus(message);
                return View(message);
            }
            else return HttpNotFound();
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                
                Message message = new Message(Convert.ToInt32(Session["AccountID"]), Convert.ToInt32(collection["Receiver"]), collection["Context"], DateTime.Now, false);
                mr.InsertMessage(message);
 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            Message message = mr.GetMessageById(id);
            if (message != null)
            {
                return View(message);
            }
            else return HttpNotFound();
        }

        // POST: Message/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Message message = new Message(Convert.ToInt32(Session["AccountID"]), Convert.ToInt32(collection["Receiver"]), collection["Context"], Convert.ToDateTime(collection["DateSend"]), Convert.ToBoolean(collection["IsRead"]));
                mr.UpdateMessage(message);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Delete/5
        public ActionResult Delete(int id)
        {
            Message message = mr.GetMessageById(id);
            if (message != null)
            {
                return View(message);
            }
            else return HttpNotFound();
        }

        // POST: Message/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                mr.DeleteMessage(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
