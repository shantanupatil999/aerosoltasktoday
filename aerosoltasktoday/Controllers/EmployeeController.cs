using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using aerosoltasktoday.Models.Data_context;

namespace aerosoltasktoday.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        aerosoltaskEntities db = new aerosoltaskEntities();
        public ActionResult Index(aerosol_table obj)
        {
            if (obj != null)
                return View(obj);
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Add(aerosol_table model)
        {
            if (ModelState.IsValid)
                try
            {
                {
                    
                    aerosol_table obj = new aerosol_table();
                    obj.Employee_Id = model.Employee_Id;
                    obj.Employee_name = model.Employee_name;
                    obj.Employee_phone = model.Employee_phone;
                    obj.Employee_salary = model.Employee_salary;
                    obj.Employee_birthdate = model.Employee_birthdate;
                    obj.Employee_email = model.Employee_email;
                    obj.Employee_qualification = model.Employee_qualification;
                    if (model.Employee_Id == 0)
                    {
                        db.Entry(obj).State = EntityState.Added;
                        db.SaveChanges();


                    }
                    else
                    {
                        db.Entry(obj).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                        ModelState.Clear();


                    }
                }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Report");

        }
        public ActionResult Report()
        {
            return View(db.sp_aerosol().ToList());
        }
        public ActionResult Delete(int id)
        {

            try
            {
                var res = db.aerosol_table.Where(m => m.Employee_Id == id).First();
                db.aerosol_table.Remove(res);
                db.SaveChanges();
                var list = db.aerosol_table.ToList();
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Report");

        }
        public ActionResult Search(string searching)
        {
            return View(db.aerosol_table.Where(m => m.Employee_name.Contains(searching) || searching == null).ToList());

        }

    }
}