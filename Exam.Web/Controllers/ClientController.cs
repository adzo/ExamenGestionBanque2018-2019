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
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        //// GET: Client/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(ClientViewModel cvm)
        {
            try
            {
                ClientService CS = new ClientService();
                Client client = new Client()
                {
                    CIN = cvm.CIN,
                    DateNaissance = cvm.DateNaissance,
                    Profession = cvm.Profession,
                    Salaire = cvm.Salaire,
                    FullName = new NomComplet()
                    {
                        LastName = cvm.FullName.LastName,
                        FirstName = cvm.FullName.FirstName
                    },
                    Address = new Address()
                    {
                        Rue = cvm.Address.Rue,
                        Ville = cvm.Address.Ville
                    }

                };
                CS.Add(client);
                CS.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Client/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Client/Edit/5
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

        //// GET: Client/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Client/Delete/5
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
