using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using EmployeeDirectory.Models;
using EmployeeDirectory.CustomAttributes;
using EmployeeDirectory.Utilities;

namespace EmployeeDirectory.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeDirectoryModel _db = new EmployeeDirectoryModel();
        private List<String> _categoryList;

        public EmployeesController()
        {
            _categoryList = null;
        }

        // GET: Employees
        public ActionResult Index(string category, string searchString)
        {
            Type type = typeof(Employee);
            if (_categoryList == null)
            {
                _categoryList = type.getMatchingPropertyNames<Searchable,Boolean>(true);
            }
            

            ViewBag.Category = new SelectList(_categoryList);

            var employees = from e in _db.Employees
                            select e;

            if (!String.IsNullOrEmpty(category) && !String.IsNullOrEmpty(searchString))
            {
                switch(category)
                {

                    case "Last Name":
                        employees = employees.Where(s => s.LastName.Contains(searchString));
                        break;
                    case "First Name":
                        employees = employees.Where(s => s.FirstName.Contains(searchString));
                        break;
                    case "Job Title":
                        employees = employees.Where(s => s.JobTitle.Description.Contains(searchString));
                        break;
                    case "Location":
                        employees = employees.Where(s => s.Location.Description.Contains(searchString));
                        break;
                }

            } 

            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.JobTitleId = new SelectList(_db.JobTitles, "Id", "Description");
            ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Description");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,WorkPhone,CellPhone,HomePhone,Email,JobTitleId,LocationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobTitleId = new SelectList(_db.JobTitles, "Id", "Description", employee.JobTitleId);
            ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Description", employee.LocationId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobTitleId = new SelectList(_db.JobTitles, "Id", "Description", employee.JobTitleId);
            ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Description", employee.LocationId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,WorkPhone,CellPhone,HomePhone,Email,JobTitleId,LocationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobTitleId = new SelectList(_db.JobTitles, "Id", "Description", employee.JobTitleId);
            ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Description", employee.LocationId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = _db.Employees.Find(id);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
