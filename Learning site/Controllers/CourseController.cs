using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Learning_site.Models;

namespace Learning_site.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        private ApplicationDbContext _context;

        public CourseController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var Courses = _context.Courses.Where(c => c.InstructorId == currentUserId).ToList();
            return View(Courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {

      

            return View();
        }

       // [Authorize(Roles ="instructor")]
        // GET: Course/Create
        public ActionResult Create()
        {




            return View();
        }




        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course c)
        {
            try
            {
                Course course = new Course(); 

                var userId = User.Identity.GetUserId();

                course.InstructorId = userId;
                course.code = c.code;
                course.name = c.name;

                _context.Courses.Add(course);
                _context.SaveChanges();


                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Course/Edit/5
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

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/5
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
