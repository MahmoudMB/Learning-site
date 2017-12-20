using Learning_site.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Learning_site.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Student

        public StudentController()
        {
            _context = new ApplicationDbContext();

        }
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var Courses = _context.EnrolledCourses.Where(c => c.StudentId == currentUserId).ToList();
            return View(Courses);

        }


        public ActionResult DisplayCourses()
        {
           
            var Courses = _context.Courses.ToList();

            return View(Courses);
        }


        public ActionResult CourseDetail(int id)
        {

            var course = _context.Courses.Include(a => a.instructor).SingleOrDefault(b => b.Id == id);
            Session["CourseId"] = id;
            return View(course);
        }



        
            public ActionResult EnrollInCourse(int id)
        {

            var currentUserId = User.Identity.GetUserId();
            // var CourseId = (int)Session["CourseId"];



            var EnrolledCourse =  _context.EnrolledCourses.Where(c => c.CourseId == id).SingleOrDefault(a=>a.StudentId == currentUserId);
           
            if (EnrolledCourse != null)
            {
              

                return Content("You are already enrolled in the course");

            }

            var enroll = new EnrolledCourse();
            enroll.CourseId = id;
            enroll.StudentId = currentUserId;

            _context.EnrolledCourses.Add(enroll);
            _context.SaveChanges();
            return View();
        }


        public ActionResult DisplayDetails()
        {
            string currentUserId = User.Identity.GetUserId();

            var Courses = _context.EnrolledCourses.Include(m => m.course).Include(m=>m.assignment).Where(c => c.StudentId == currentUserId).ToList();

            return View(Courses);
        }







        public ActionResult DisplayEnrolled()
        {
            string currentUserId = User.Identity.GetUserId();
            var Courses = _context.EnrolledCourses.Include(m=>m.course).Where(c => c.StudentId == currentUserId).ToList();

            return View(Courses);
        }




        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
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

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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
