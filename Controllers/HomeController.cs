using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using RotaryClubOfTruro.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace RotaryClubOfTruro.Controllers {

    public class HomeController : Controller {

        private IWebHostEnvironment environment;
        public HomeController(IWebHostEnvironment env) {
            environment = env;
        }

        public IActionResult Index() {

            StudentManager studentManager = new StudentManager();
            
            return View(studentManager);

        }

        public IActionResult Add(int schoolID, StudentManager studentManager) {
            // construct Student object that will be used to add a new student

            // if (!ModelState.IsValid) return RedirectToAction("index");

            Student student = new Student();
            Info info = new Info();
            Files files = new Files();
            ViewBag.selectList = studentManager.justschools();

            // pass it into the view for populating
            return View(student);
        }

        
        [HttpPost]
        public IActionResult AddSubmit(int schoolID, Student student, Info info, Files files, StudentManager studentManager, IFormFile selectedFile1, IFormFile selectedFile2) {
            // if (!ModelState.IsValid) return RedirectToAction("index");
            // take form data and create new customer in DB
            ViewBag.selectList = studentManager.justschools();
            
            FileUploader fileUploader = new FileUploader(environment, "uploads");
            int result1 = fileUploader.uploadFile(selectedFile1);
            string resume = fileUploader.fileName;
            int result2 = fileUploader.uploadFile(selectedFile2);
            string transcript = fileUploader.fileName;

            if (result1 != 5 && result2 == 5) {
                    fileUploader.deleteFile(transcript);
                    ViewData["feedbacksuccess2"] = "Please make sure to upload both files!";
            }

            if(result1 == 0 && result2 == 0 ){
                    ViewData["feedback1"] = "Sorry no file was selected please try again:)";
                    ViewData["feedback2"] = "Sorry no file was selected please try again:)";
                }
                else if (result1 == 1) {
                    ViewData["feedback1"] = "File type not permitted";
                    ViewData["feedbacksuccess2"] = "Please make sure to upload both files!";
                } else if (result1 == 2) {
                    ViewData["feedback1"] = "File exceeds the size limit";
                    ViewData["feedbacksuccess2"] = "Please make sure to upload both files!";
                } else if (result1 == 3) {
                    ViewData["feedback1"] = "File name must be under 100 characters";
                    ViewData["feedbacksuccess2"] = "Please make sure to upload both files!";

                } else if (result1 == 4) {
                    ViewData["feedback1"] = "Error occurred in saving the file";
            }

            if (result1 == 5 && result2 != 5) {
                    fileUploader.deleteFile(resume);
                    ViewData["feedbacksuccess2"] = "Please make sure to upload both files!";
            }
        
            // if(result2 == 0 ){
            //         ViewData["feedback2"] = "Sorry no file was selected please try again:)";
            //     }
                if (result2 == 1) {
                    ViewData["feedback2"] = "File type not permitted";
                } else if (result2 == 2) {
                    ViewData["feedback2"] = "File exceeds the size limit";
                } else if (result2 == 3) {
                    ViewData["feedback2"] = "File name must be under 100 characters";
                } else if (result2 == 4) {
                    ViewData["feedback2"] = "Error occurred in saving the file";
            }

            else{
                
                Console.WriteLine("upload result: " + result1);
                string message = "";
                // set message to display to user to the image upload result
                message = studentManager.uploadResult(result1);
                message = studentManager.uploadResult(result2);
                // message = studentManager.uploadResult(result3);
                ViewData["imageFeedback"] = message;
                // if image meets all requirements, get the form data
                if (result1 == 5 && result2 == 5 ) {

                    if (!ModelState.IsValid) return RedirectToAction("index");
                    // files.refLetter = refLetter;
                    files.resume = resume;
                    files.transcript = transcript;

                    ViewBag.info = info;
                    ViewBag.files = files;
        
                    studentManager.Add(info);
                    studentManager.SaveChanges();
                    student.infoID = info.infoID;
                    studentManager.Add(files);
                    studentManager.SaveChanges();
                    student.fileID = files.fileID;
                    studentManager.Add(student);
                    studentManager.SaveChanges();

                    return RedirectToAction("SuccessfulPage");
                }
            }

            return View("Add");
        }

        public IActionResult SuccessfulPage() {
            return View();
        }
        
        public IActionResult Cancel() {
            return View("Index");
        }

    }
}
