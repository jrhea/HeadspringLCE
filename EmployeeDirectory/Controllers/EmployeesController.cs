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
using System.Web.Security;
using System.Security.Principal;
using PagedList;
using EmployeeData;
using EmployeeData.CustomAttributes;
using EmployeeDirectory.Utilities;
using System.Diagnostics;


namespace EmployeeDirectory.Controllers
{
    public class EmployeesController : Controller
    {
        private List<String> _categoryDisplayNames;
        private string _username;
        EmployeeServiceRef.EmployeeServiceClient _esc;
        ModelHelper _modelHelper;

        public EmployeesController()
        {
            _categoryDisplayNames = null;
            _username = "";
            InitializeSession();
        }

        public EmployeesController(string username)
        {
            _categoryDisplayNames = null;
            _username = username;
            InitializeSession();
        }

        // GET: Employees
        public ActionResult Index(string category, string currentFilter, string searchString, int? page)
        {
            ViewResult result;
            Type type = typeof(EmployeeData.Employee);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.Category = category;

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
                List<Employee> matches = new List<Employee>();
                PropertyInfo info = type.getMatchingProperties<DisplayNameAttribute, String>(category, "DisplayName").First();
                foreach (Employee employee in employees)
                {
                    if(info.GetValue(employee).ToString().Contains(searchString))
                    {
                        matches.Add(employee);
                    }
                }
                result = View(matches.ToPagedList(pageNumber,pageSize));
            }
            else
            {
                Session["ModelHelper"] = _modelHelper;
                result = View(employees.ToPagedList(pageNumber,pageSize));
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
            _modelHelper.Employee = _esc.GetEmployee(id.Value);
            if (_modelHelper.Employee == null)
            {
                return HttpNotFound();
            }
            return View(_modelHelper);
        }

        // GET: Employees/Create
        [CustomAuthorize(Roles = "HR")]
        public ActionResult Create()
        {
            ViewBag.Role = new SelectList(_modelHelper.Roles, "Id", "Description", 0);
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "HR")]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,WorkPhone,CellPhone,HomePhone,Email,JobTitle,Location,RoleId")] Employee employee)
        {
            _modelHelper.Employee = employee;
            if (ModelState.IsValid)
            {
                _esc.CreateEmployee(_modelHelper.Employee);
                return RedirectToAction("Index");
            }
            
            return View(_modelHelper);
        }

        // GET: Employees/Edit/5
        [CustomAuthorize(Roles = "HR")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _modelHelper.Employee = _esc.GetEmployee(id.Value);
            if (_modelHelper.Employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role = new SelectList(_modelHelper.Roles, "Id", "Description", 0);

            return View(_modelHelper.Employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "HR")]
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
        [CustomAuthorize(Roles = "HR")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _esc.GetEmployee(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "HR")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = _esc.GetEmployee(id);
            _esc.DeleteEmployee(employee);
            return RedirectToAction("Index");
        }

        protected void InitializeSession()
        {
            _esc = new EmployeeServiceRef.EmployeeServiceClient();
            if (Session != null)
            {
                _modelHelper = (ModelHelper)Session["ModelHelper"];
            }
            else
            {
                _modelHelper = new ModelHelper();
            }
            _modelHelper.Roles = _esc.GetAllRoles();
            EstablishSessionIdentity();
        }

        public void EstablishSessionIdentity()
        {
            try
            {
                if (_username.Equals(String.Empty))
                {
                    _username = WindowsIdentity.GetCurrent().Name.Split(new string[1] { "\\" }, StringSplitOptions.None)[1];
                }
                _modelHelper.SessionIdentity = _esc.GetEmployee(Convert.ToInt32(_username));
            }
            catch (System.FormatException)
            {
                _modelHelper.CreateGuestIdentity();
            }
        }

        protected override void Dispose(bool disposing)
        {
            _esc.Close();
            base.Dispose(disposing);
        }
    }
}
