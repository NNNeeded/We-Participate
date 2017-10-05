using ProftaakASP.App_DAL;
using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProftaakASP.Controllers
{
    public class RequestController : Controller
    {
        //Maak een repository aan zodat je gebruik kan maken van de methodes in de requestSQLContext
        RequestRepository rr = new RequestRepository(new RequestSQLContext());
        // GET: Request
        public ActionResult Index()
        {
            List<Request> requests = rr.GetAllRequests();
            return View(requests);
        }

        // GET: Request/Details/5
        public ActionResult Details(int id)
        {
            Request request = rr.GetRequestById(id);
            if (request != null)
            {
                return View(request);
            }
            else return HttpNotFound();
        }

        // GET: Request/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Request/Create
        // Om de data te versturen wordt een FormCollection gebruikt
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Request request = new Request(Convert.ToInt32(Session["AccountId"]), collection["Title"], collection["Context"], DateTime.Today, Convert.ToDateTime(collection["DateHelpNeeded"]), Convert.ToInt32(collection["CategoryID"]));
                rr.InsertRequest(request);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Edit/5
        // Hier vraag ik de gegevens op zodat ik deze in een textbox kan plaatsen voor makkelijk edite
        public ActionResult Edit(int id)
        {
            Request request = rr.GetRequestById(id);
            if (request != null)
            {
                return View(request);
            }
            else return HttpNotFound();
        }

        // POST: Request/Edit/5
        // Hier zorg ik ervoor dat wanneer de gegevens geedit zijn dat wanneer op de opslaan knop gedrukt wordt de gegevens worden geupdate
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Request request = new Request(Convert.ToInt32(collection["AccountID"]), collection["Title"], collection["Context"], Convert.ToDateTime(collection["DatePlaced"]), Convert.ToDateTime(collection["DateHelpNeeded"]), Convert.ToInt32(collection["CategoryID"]));
                rr.UpdateRequest(request);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Delete/5
        // Hier laad ik de gegevens in van de persoon die gedelete gaat worden
        public ActionResult Delete(int id)
        {
            Request request = rr.GetRequestById(id);
            if (request != null)
            {
                return View(request);
            }
            else return HttpNotFound();
        }

        // POST: Request/Delete/5
        // Hier geef ik aan dat wanneer er op de knop gedrukt wordt de request met het gelinkte id gedelete wordt.
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                rr.DeleteRequest(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
