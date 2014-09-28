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
using EmployeeData;
using EmployeeData.CustomAttributes;
using EmployeeDirectory.Utilities;

namespace EmployeeDirectory.Controllers
{
    public class EmployeesController : Controller
    {
        private List<String> _categoryDisplayNames;
        EmployeeServiceRef.EmployeeServiceClient _esc;
        CompositeModel _compositeModel;

        public EmployeesController()
        {
            _categoryDisplayNames = null;
            _compositeModel = new CompositeModel();
            _esc = new EmployeeServiceRef.EmployeeServiceClient();
        }

        // GET: Employees
        public ActionResult Index(string category, string searchString)
        {
            ViewResult result;
            Type type = typeof(EmployeeData.IEmployee);

            //This is just a clever way of using Reflection and Extension methods 
            //in order to not have to maintain a list of "Searchable" properties
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
           
             var employees = _esc.GetAllEmployees().AsQueryable();

            //Find the Employee objects with property that matches criteria
            if (!String.IsNullOrEmpty(category) && !String.IsNullOrEmpty(searchString))
            {
                List<IEmployee> matches = new List<IEmployee>();
                PropertyInfo info = type.getMatchingProperties<DisplayNameAttribute, String>(category, "DisplayName").First();
                foreach (IEmployee employee in employees)
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
                _compositeModel.Employees = employees.ToList<IEmployee>();
                _compositeModel.Roles = _esc.GetAllRoles();
                Session["Composite"] = _compositeModel;
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
            _compositeModel = (CompositeModel)Session["Composite"];
            _compositeModel.CurrentEmployee = _esc.GetEmployee(id.Value);
            if (_compositeModel.CurrentEmployee == null)
            {
                return HttpNotFound();
            }
            return View(_compositeModel);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            _compositeModel = (CompositeModel)Session["Composite"];
            ViewBag.Role = new SelectList(_compositeModel.Roles, "Id", "Description", 0);
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,WorkPhone,CellPhone,HomePhone,Email,JobTitle,Location,RoleId")] Employee employee)
        {
            _compositeModel = (CompositeModel)Session["Composite"];
            _compositeModel.CurrentEmployee = employee;
            if (ModelState.IsValid)
            {
                _esc.CreateEmployee(_compositeModel.CurrentEmployee);
                return RedirectToAction("Index");
            }
            
            return View(_compositeModel);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _compositeModel = (CompositeModel)Session["Composite"];
            _compositeModel.CurrentEmployee = _esc.GetEmployee(id.Value);
            if (_compositeModel.CurrentEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role = new SelectList(_compositeModel.Roles, "Id", "Description", 0);

            return View(_compositeModel.CurrentEmployee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,WorkPhone,CellPhone,HomePhone,Email,JobTitle,Location,RoleId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _esc.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEmployee employee = _esc.GetEmployee(id.Value);
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
            IEmployee employee = _esc.GetEmployee(id);
            _esc.DeleteEmployee(employee);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
