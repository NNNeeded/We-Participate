using ProftaakASP.App_DAL;
using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProftaakASP.Controllers
{
    public class OfferController : Controller
    {
        OfferRepository or = new OfferRepository(new OfferSQLContext());
        RequestRepository rr = new RequestRepository(new RequestSQLContext());
        Offer offer;

        // GET: Offer
        public ActionResult Index()
        {
            List<Offer> offers = or.GetAllOffers();
            return View(offers);
        }

        // GET: Offer/Details/5
        public ActionResult Details(int id)
        {
            Offer offer = or.GetOfferInfo(id);
            if (offer != null)
            {
                return View(offer);
            }
            else return HttpNotFound();
        }

        // GET: Offer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, int id)
        {
            try
            {
                // TODO: Add insert logic here
                Request request = rr.GetRequestById(id);
                Session["RequestID"] = request.Id;
                Offer offer = new Offer(Convert.ToInt32(Session["AccountID"]), Convert.ToInt32(Session["RequestID"]), collection["Title"], collection["Context"]);
                or.InsertOffer(offer);


                //Offer offer = new Offer(Convert.ToInt32(Session["AccountId"]), collection["Title"], collection["Context"]);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Offer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Offer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Offer/Delete/5
        public ActionResult Delete(int id)
        {
            Offer offer = or.GetOfferInfo(id);
            if (offer != null)
            {
                return View(offer);
            }
            else return HttpNotFound();
        }

        // POST: Offer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                or.DeleteOffer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
