using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Learning_site.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Learning_site.Controllers
{
    public class RolesController : Controller
    {

        private ApplicationDbContext _context;

        public RolesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Roles
        public ActionResult Index()
        {
            return View(_context.Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole identityRole)
        {
            
                if (ModelState.IsValid)
                {
                    _context.Roles.Add(identityRole);
                    _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(identityRole);
               
         
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Roles/Edit/5
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

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Roles/Delete/5
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
