using ProftaakASP.App_DAL;
using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProftaakASP.Controllers
{
    public class AccountController : Controller
    {
        //Maak een repository aan zodat je gebruik kan maken van de methodes in de accountSQLContext
        AccountRepository ar = new AccountRepository(new AccountSQLContext());

        // GET: Account
        // GET: Account betekend dat deze pagina data vraagt van een bepaalde source
        // Hier wordt beschreven wat ik wil laten zien op de index pagina van de account view
        public ActionResult Index()
        {
            // Hier maak ik een lijst aan die nodig is om alle accounts in op te slaan, vervolgens vul ik de lijst met alle accounts via de repository
            List<Account> accounts = ar.GetAllAccounts();
            return View(accounts);
        }

        // GET: Account/Details/5
        // Hier wordt beschreven wat ik wil laten zien op de details pagina van de account view
        public ActionResult Details(int id)
        {
            // Hier maak ik een account aan en omdat je een account kiest waarvan je de details wilt zien moet het id van dat account doorgegeven worden.
            Account account = ar.GetAccountById(id);
            if (account != null)
            {
                return View(account);
            }
            else return HttpNotFound();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // POST: Account/Create betekend dat deze pagina data stuurt naar een bepaalde source
        // Om de data te versturen wordt een FormCollection gebruikt
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Account account = new Account(collection["PhoneNumber"], collection["Email"], collection["Username"], collection["Password"], collection["Rank"], collection["FirstName"], collection["LastName"], Convert.ToDateTime(collection["BirthYear"]), collection["City"], collection["Street"], collection["HouseNumber"], collection["Zipcode"], collection["Gender"], collection["ProfileDescription"], Convert.ToInt32(collection["PreferredCategory"]));
                ar.InsertAccount(account);
                return RedirectToAction("Index", "Login");
            }
            catch
            {
                return View("Index", "Login");
            }
        }

        // GET: Account/Edit/5
        // Hier vraag ik de gegevens op zodat ik deze in een textbox kan plaatsen voor makkelijk editen
        public ActionResult Edit(int id)
        {
            Account account = ar.GetAccountById(id);
            if (account != null)
            {
                return View(account);
            }
            else return HttpNotFound();
        }

        // POST: Account/Edit/5
        // Hier zorg ik ervoor dat wanneer de gegevens geedit zijn dat wanneer op de opslaan knop gedrukt wordt de gegevens worden geupdate
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Account account = new Account(collection["PhoneNumber"], collection["Email"], collection["Username"], collection["Password"], collection["Rank"], collection["FirstName"], collection["LastName"], Convert.ToDateTime(collection["BirthYear"]), collection["City"], collection["Street"], collection["HouseNumber"], collection["Zipcode"], collection["Gender"], collection["ProfileDescription"], Convert.ToInt32(collection["PreferredCategory"]));
                ar.UpdateAccount(account);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        // Hier laad ik de gegevens in van de persoon die gedelete gaat worden
        public ActionResult Delete(int id)
        {
            Account account = ar.GetAccountById(id);
            if (account != null)
            {
                return View(account);
            }
            else return HttpNotFound();
        }

        // POST: Account/Delete/5
        // Hier geef ik aan dat wanneer er op de knop gedrukt wordt het account met het gelinkte id gedelete wordt.
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ar.DeleteAccount(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
