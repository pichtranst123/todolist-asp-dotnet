    using entityframeworkStudent.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;


    namespace entityframeworkStudent.Controllers
    {
        public class StudentsController : Controller
        {
            // GET: Students
            public ActionResult Index()
            {
                var listStudent = new DBContextStudent().Students.ToList();
                return View(listStudent);
            }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new DBContextStudent())
            {
                var student = db.Students.FirstOrDefault(s => s.id == id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            }
        }

        // GET: Students/Create
        public ActionResult Create()
            {
                return View();
            }

            // POST: Students/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new DBContextStudent())
                    {
                        db.Students.Add(student);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                return View(student);
            }
            catch
            {
                return View(student);
            }
        }


        // GET: Students/Edit/5
        public ActionResult Edit(int id)
            {
            using (var db = new DBContextStudent())
            {
                var student = db.Students.FirstOrDefault(s => s.id == id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            }
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student studentToUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new DBContextStudent())
                    {
                        var student = db.Students.FirstOrDefault(s => s.id == id);
                        if (student == null)
                        {
                            return HttpNotFound();
                        }

                        // Update properties
                        student.name = studentToUpdate.name;
                        student.age = studentToUpdate.age;
                        student._class = studentToUpdate._class;

                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                return View(studentToUpdate);
            }
            catch
            {
                // Handle the error
                return View(studentToUpdate);
            }
        }


        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new DBContextStudent())
            {
                var student = db.Students.FirstOrDefault(s => s.id == id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            }
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                using (var db = new DBContextStudent())
                {
                    var student = db.Students.FirstOrDefault(s => s.id == id);
                    if (student != null)
                    {
                        db.Students.Remove(student);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                // Ideally, add some logging or error handling here
                return RedirectToAction("Delete", new { id = id });
            }
        }

    }
}
