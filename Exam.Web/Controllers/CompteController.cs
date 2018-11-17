using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exam.Domain.Entities;
using Exam.Service;
using Exam.Web.Models;

namespace Exam.Web.Controllers
{
    public class CompteController : Controller
    {
        // GET: Compte
        public ActionResult Index()
        {
            string cin = Session["Cin"].ToString();
            ClientService CS = new ClientService();
            Client client = CS.GetAll().FirstOrDefault(c => c.CIN.Equals(cin));
            List<CompteViewModel> lcvm = new List<CompteViewModel>();
            foreach (var compte in client.Comptes)
            {
                CompteViewModel cvm = new CompteViewModel()
                {
                    RIB = compte.RIB,
                    DateOuverture = compte.DateOuverture,
                    Solde = compte.Solde,
                   CIN = compte.CIN,
                    AgenceKey = compte.AgenceKey
                };
                lcvm.Add(cvm);
            }

            ViewData["FirstName"] = client.FullName.FirstName;
            ViewData["LastName"] = client.FullName.LastName;
            return View(lcvm);
        }

        ////GET: Compte/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Compte/Create
        public ActionResult Create()
        {
            ClientService CS = new ClientService();
            List<ClientViewModel> lcvm = new List<ClientViewModel>();
            foreach (var item in CS.GetAll())
            {
                ClientViewModel loc = new ClientViewModel()
                {
                    CIN = item.CIN,
                    FullName = new NomCompletViewModel()
                    {
                        LastName = item.FullName.LastName,
                        FirstName = item.FullName.FirstName
                    }

                };
                lcvm.Add(loc);
            }

            ViewData["Clients"] = new SelectList(lcvm, "CIN", "FullName");
            return View();
        }

        // POST: Compte/Create
        [HttpPost]
        public ActionResult Create(CompteViewModel cvm)
        {
            try
            {
                // TODO: Add insert logic here
                CompteCourantService CS = new CompteCourantService();
                CompteCourant account = new CompteCourant()
                {
                    AgenceKey = 1,
                    CIN = cvm.CIN,
                    DateOuverture = cvm.DateOuverture,
                    Solde = cvm.Solde,
                    DecouvertMax = 240f
                };
                CS.Add(account);
                CS.Commit();
                Session["Cin"] = cvm.CIN;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Compte/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Compte/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Compte/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Compte/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
