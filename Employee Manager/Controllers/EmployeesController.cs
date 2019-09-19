using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Employee_Manager;

namespace Employee_Manager.Controllers
{
    public class EmployeesController : Controller
    {
        private ECMEntities db = new ECMEntities();

        // GET: Employees
        public ActionResult Index()
        {
            int? deptFilterId = -1;
            if (Request != null && Request["cboDeptFilter"] != null) 
                deptFilterId = int.Parse(Request["cboDeptFilter"]);

            var employees = (deptFilterId != null && deptFilterId > -1)
                ? db.Employees.Where(x => x.DepartmentId == deptFilterId).Include(e => e.Department)
                : db.Employees.Include(e => e.Department);
                      
            List<SelectListItem> temp = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem();
            sli.Text = "--- Select One ---";
            sli.Value = "-2";
            temp.Add(sli);
            sli = new SelectListItem();
            sli.Text = "All Departments";
            sli.Value = "-1";
            temp.Add(sli);
            foreach (Department d in db.Departments)
            {
                sli = new SelectListItem();
                sli.Text = d.Name;
                sli.Value = d.DepartmentId.ToString();                
                temp.Add(sli);
            }
            SelectList sl = new SelectList(temp, "Value", "Text", deptFilterId);
            ViewData["DeptFilter"] = new SelectList(sl, "Value", "Text");
            
            return View(employees.ToList());
        }


        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,DepartmentId,FirstName,LastName,WorkPhone,DeskLocation,HomePhone,HomeAddress1,HomeAddress2,HomeCity,HomeState,HomeZip")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,DepartmentId,FirstName,LastName,WorkPhone,DeskLocation,HomePhone,HomeAddress1,HomeAddress2,HomeCity,HomeState,HomeZip")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
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
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
