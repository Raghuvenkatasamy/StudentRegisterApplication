using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DataAccessLayer;

namespace Student_Register_Application.Controllers
{
    public class StudentRegisterController : Controller
    {
        private readonly IStudentDetailsRepository _stuobj;
        private readonly ISubjectcsRepository _subOj;
        private readonly string _connectionstring;

        public StudentRegisterController(IStudentDetailsRepository studObj, IConfiguration configuration, ISubjectcsRepository subObj)
        {
            _stuobj = studObj;
            _subOj = subObj;
            _connectionstring = configuration.GetConnectionString("DbConnection");
        }
        // GET: StudentRegisterController
        public ActionResult Index()
        {
            try
            {
                var Listview = _stuobj.ListAll();
                if (Listview == null)
                {
                    return View("StudentDetailsView", Listview);
                }
                else
                {
                    ViewBag.Message = "No Student Records";

                    return View("StudentDetailsView", Listview);
                }
            }catch
            {
                return View("Error");
            }
        }

        // GET: StudentRegisterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentRegisterController/Create
        public ActionResult Create()
        {
            try
            {
                var create = new StudentDetails();
                create.Subject = _subOj.Listsubject().ToList();
                return View("StudentDetailsCreate", create);
            }
            catch 
            {
                return View("Error");
            }
            
        }

        // POST: StudentRegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDetails register)
        {
            try
            {
                if (register.Age < 18)
                {

                    return View("Invalid");
                }
                else
                {
                    _stuobj.InsertRecord(register);
                    TempData["SuccessMessage"] = $"Student Registered successfully-ID={register.StudentID}";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View("Error");
            }
           
        }

        // GET: StudentRegisterController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {

                var num = _stuobj.SelectByID(id);
                num.Subject = _subOj.Listsubject().ToList();
                return View("StudentDetailsEdit", num);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: StudentRegisterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentDetails register)
        {
            try
            {
                if (register.Age < 18)
                {
                    return View("Invalid");
                }
                else
                {
                   var updaterecord= _stuobj.UpdateRecord(id, register);
                    TempData["SuccessMessage"] = $"Updated successfully-ID={id}";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: StudentRegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var num = _stuobj.SelectByID(id);
                return View("StudentDetailsDeleteView", num);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: StudentRegisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletebyId(int StudentID)
        {
            try
            {
                _stuobj.DeleteRecord(StudentID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
