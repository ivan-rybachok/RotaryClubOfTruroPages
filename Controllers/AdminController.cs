using System;
using Microsoft.AspNetCore.Mvc;
using RotaryClubOfTruro.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace RotaryClubOfTruro.Controllers {

    public class AdminController : Controller {

        private IWebHostEnvironment environment;
        public AdminController(IWebHostEnvironment env) {
            environment = env;
        }

        public IActionResult Index() {

            StudentManager studentManager = new StudentManager();

            if(HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index", "Login");
            }

            int schoolID = studentManager.schoolID;
            
            School school = new School();
        
            ViewBag.selectList = studentManager.getSelectedSchool();

            if(schoolID == 0) {
                List<Student> allstudents = studentManager.getAllStudents();
                ViewBag.list = allstudents;
            }
            
            return View(studentManager);
        }
        
        [Route("Admin/StudentName/{appID}")]
        public IActionResult StudentName(Student student, string appID, StudentManager studentManager ) {

            if(HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index", "Login");
            }

            if (TempData["appID"] != null) {
                student = studentManager.getStudent(Convert.ToInt32(TempData["appID"]));
            } else {
                student = studentManager.getStudent(Convert.ToInt32(appID));
            }

            List<Info> info = studentManager.getInfo(student.infoID);
            ViewBag.list = info;
            List<Files> files = studentManager.getFiles(student.fileID);
            ViewBag.files = files;

            return View(student);

        }

        [HttpPost]
        public IActionResult SelectedSchoolDropDown(StudentManager studentManager) {

            if(HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index", "Login");
            }

            School school = new School();

            ViewBag.selectList = studentManager.getSelectedSchool();

            int schoolID = studentManager.schoolID;

            if(schoolID == 0) {
                // Console.WriteLine("HEllo1");
                List<Student> allstudents = studentManager.getAllStudents();
                ViewBag.list = allstudents;
                // Console.WriteLine(schoolID);
            }else{
                
                List<Student> student = studentManager.getStudentsSchoolID(schoolID);
                ViewBag.list = student;
            }
            
            return View("ChosenSchool", studentManager);
        }

        [Route("Admin/Delete/{appID}")] 

        public IActionResult Delete(Student student, StudentManager studentManager, string appID) {

            if(HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index", "Login");
            }

            if (TempData["appID"] != null) {
                student = studentManager.getStudent(Convert.ToInt32(TempData["appID"]));
            } else {
                student = studentManager.getStudent(Convert.ToInt32(appID));
            }

            return View(student);
            // return RedirectToAction("index");

        }

        [HttpPost]
        public IActionResult DeleteSubmit(Student student, Info info, Files file, StudentManager studentManager) {

            // student.appID = Convert.ToInt32(TempData["appID"]);

            student = studentManager.getStudent(Convert.ToInt32(student.appID));

            info = studentManager.getInfoID(Convert.ToInt32(student.infoID));
            
            file = studentManager.getFileID(Convert.ToInt32(student.fileID));

            studentManager.Remove(student);
            studentManager.SaveChanges();
           
            // info.infoID = Convert.ToInt32(TempData["infoID"]);
            // file.fileID = Convert.ToInt32(TempData["fileID"]);
        
            studentManager.Remove(info);
            studentManager.SaveChanges();


            FileUploader fileUploader = new FileUploader(environment, "uploads");
            // get the name of the selected quote's image
            // string file1 = file.refLetter;
            string file1 = file.resume;
            string file2 = file.transcript;
            // delete the image file if it exists on the server
            // fileUploader.deleteFile(file1);
            fileUploader.deleteFile(file1);
            fileUploader.deleteFile(file2);
            

            studentManager.Remove(file);
            studentManager.SaveChanges();



            return RedirectToAction("index");

        }
        
        public IActionResult DeleteAll(StudentManager studentManager){

            if(HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index", "Login");
            }

            return View(studentManager);
        }

        public IActionResult DeleteAllSubmit(StudentManager studentManager){

            List<Student> allstudentsdelete = studentManager.getAllStudents();

            List<Info> allinfosdelete = studentManager.getAllInfos();
            
            List<Files> allfilesdelete = studentManager.getAllFiles();

            FileUploader fileUploader = new FileUploader(environment, "uploads");
            // get the name of the selected quote's image
        
            foreach (var s in allstudentsdelete) {
               
                studentManager.Remove(s);
                studentManager.SaveChanges();
            } 
            foreach (var i in allinfosdelete) {
               
                studentManager.Remove(i);
                studentManager.SaveChanges();
            } 
            foreach (var f in allfilesdelete) {

                // string file1 = f.refLetter;
                string file1 = f.resume;
                string file2 = f.transcript;
                // delete the image file if it exists on the server
                // fileUploader.deleteFile(file1);
                fileUploader.deleteFile(file1);
                fileUploader.deleteFile(file2);
               
                studentManager.Remove(f);
                studentManager.SaveChanges();
            } 

            return RedirectToAction("index");
        }

        public IActionResult Cancel() {
            return View();
        }
    }
}