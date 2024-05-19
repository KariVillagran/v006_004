using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSIntegracionPlataformas.Utils.WEBPAY
{
    public class WEBPAYController : Controller
    {
        // GET: WEBPAY
        public ActionResult Index()
        {
            return View();
        }

        // GET: WEBPAY/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WEBPAY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WEBPAY/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WEBPAY/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WEBPAY/Edit/5
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

        // GET: WEBPAY/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WEBPAY/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
