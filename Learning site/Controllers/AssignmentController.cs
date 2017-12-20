using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Learning_site.Models;
using System.IO;

namespace Learning_site.Controllers
{
    public class AssignmentController : Controller
    {
        private ApplicationDbContext _context;

        public AssignmentController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Assignment

  

          //  [Route("Assignment/{Id}")]

        public ActionResult Index(int Id)
        {


            Session["CourseID"] = Id;
            string currentUserId = User.Identity.GetUserId();

            var Assignments = _context.Assignments.Where(c => c.studentId == currentUserId).Where(c=>c.courseId== Id).ToList();

            
            return View(Assignments);


        }




        // GET: Assignment/Create
        public ActionResult Create()
        {


            return View();
        }
        // POST: Assignment/Create
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create(Assignment assignment,HttpPostedFileBase uploadAssign)
        {

           string path = Path.Combine(Server.MapPath("~/upload/Assignments"), uploadAssign.FileName);
           uploadAssign.SaveAs(path);
            string currentUserId = User.Identity.GetUserId();
           assignment.File = uploadAssign.FileName;
            assignment.courseId = (int)Session["CourseID"];

            assignment.studentId = currentUserId;
                _context.Assignments.Add(assignment);
                _context.SaveChanges();

         //   return View();
             return RedirectToAction("Index",new { id=assignment.courseId});

        }

        // GET: Assignment/Edit/5
        public ActionResult Edit(int id)
        {
            var Assignment = _context.Assignments.SingleOrDefault(a => a.Id == id);

            return View(Assignment);
        }

        // POST: Assignment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Assignment assignment, HttpPostedFileBase uploadAssign)
        {
            try
            {
                // TODO: Add update logic here
                var assignInDb = _context.Assignments.SingleOrDefault(a => a.Id == assignment.Id);

                if (assignInDb == null)
                    return HttpNotFound();

                if (uploadAssign != null)
                {
                    string path = Path.Combine(Server.MapPath("~/upload/Assignments"), uploadAssign.FileName);
                    uploadAssign.SaveAs(path);
                    assignInDb.File = uploadAssign.FileName;
                }

                assignInDb.subject = assignment.subject;
                _context.SaveChanges();

                return RedirectToAction("Index", new { id = assignInDb.courseId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Assignment/Delete/5
        public ActionResult Delete(int id)
        {

            var assignment = _context.Assignments.SingleOrDefault(a => a.Id == id);
            _context.Assignments.Remove(assignment);
            _context.SaveChanges();

            return RedirectToAction("Index",new { id=assignment.courseId});


            return View();
        }

        // POST: Assignment/Delete/5
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
