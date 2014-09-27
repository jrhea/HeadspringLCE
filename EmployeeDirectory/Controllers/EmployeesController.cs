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
using System.ComponentModel;
using EmployeeDirectory.Models;
using EmployeeDirectory.CustomAttributes;
using EmployeeDirectory.Utilities;

namespace EmployeeDirectory.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeDirectoryModel _db = new EmployeeDirectoryModel();
        private List<String> _categoryDisplayNames;
        public EmployeesController()
        {
            _categoryDisplayNames = null;
        }

        // GET: Employees
        public ActionResult Index(string category, string searchString)
        {
            ViewResult result;
            Type type = typeof(Employee);
            if (_categoryDisplayNames == null)
            {
                //Find properties of Employee that have SearchableAttribute with Value = true
                List<PropertyInfo> propList1 = type.getMatchingProperties<Searchable,Boolean>(true);
                //Find properties of Employee that have DisplayAttribute
                List<PropertyInfo> propList2 = type.getMatchingProperties<DisplayNameAttribute>();
                //Find the intersection of the two lists 
                 List<PropertyInfo> categoryPropInfos = propList1.Intersect(propList2).ToList<PropertyInfo>();
                //Get list of user friendly names for properties
                 _categoryDisplayNames = categoryPropInfos.Select(x => x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).ToList<String>();
            }


            ViewBag.Category = new SelectList(_categoryDisplayNames);

            var employees = from e in _db.Employees
                            select e;
            
            if (!String.IsNullOrEmpty(category) && !String.IsNullOrEmpty(searchString))
            {
                List<Employee> matches = new List<Employee>();
                PropertyInfo info = type.getMatchingProperties<DisplayNameAttribute, String>(category, "DisplayName").First();
                //Find the Employee objects with property that matches criteria
                foreach (Employee employee in employees)
                {
                    if(info.GetValue(employee).ToString().Contains(searchString))
                    {
                        matches.Add(employee);
                    }
                }
                result = View(matches);
            }
            else
            {

                result = View(employees);
            }
            return result;
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
