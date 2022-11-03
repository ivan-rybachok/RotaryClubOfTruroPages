using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace RotaryClubOfTruro.Models {

    public class StudentManager : DbContext {
        

        private DbSet<Student> tblStudent {get; set;}
        private DbSet<School> tblSchool {get; set;}
        private DbSet<Info> tblInfo {get; set;}
        private DbSet<Files> tblFiles {get; set;}
        public int count {get; set;} = 1;
        public int schoolID {get; set;} = 0;
        public const int ERROR_TYPE = 1;
        public const int ERROR_SIZE = 2;
        public const int ERROR_NAME_LENGTH = 3;
        public const int ERROR_SAVE = 4;
        public const int SUCCESS = 5;
        private const int UPLOADLIMIT = 4194304;
        public string targetFolder;
        // path to the upload folder
        public string fullPath;
        // increment number to add to the duplicate image name 
        public int number = 0;
        public string image {get; set;}
        

        public List<Student> students {
            get {
                return tblStudent.OrderBy(a => a.appID).ToList();
            }
        }

        public List<School> schools {
            get {
                return tblSchool.OrderBy(s => s.schoolID).ToList();
            }
        }

        public List<Info> info {
            get {
                return tblInfo.OrderBy(i => i.infoID).ToList();
            }
        }

        public List<Files> files {
            get {
                return tblFiles.OrderBy(i => i.fileID).ToList();
            }
        }

        public List<Info> getInfo(int infoID) {

            return tblInfo.Where(i => i.infoID == (infoID)).ToList();
            

        }
        public List<Files> getFiles(int fileID) {

            return tblFiles.Where(i => i.fileID == (fileID)).ToList();
            
        }

        public SelectList getSelectedSchool() {

            List<School> schoolData = tblSchool.OrderBy(s => s.schoolID).ToList();
            return new SelectList(schoolData, "schoolID", "schoolName");
        }

        public Student getStudent(int appID) {

            Student student = new Student();

            student = tblStudent.Find(appID);

            return student;
           
        }

        public Info getInfoID(int infoID) {

            Info info = new Info();

            info = tblInfo.Find(infoID);

            return info;
           
        }

        public Files getFileID(int fileID) {

            Files file = new Files();

            file = tblFiles.Find(fileID);

            return file;
           
        }

        public List<Student> getStudentsSchoolID(int schoolID) {

            return tblStudent.Where(s => s.schoolID == (schoolID)).ToList();
            
        }

        public List<Student> getAllStudents() {

            return tblStudent.OrderBy(a => a.appID).ToList();
            
        }
        public List<Info> getAllInfos() {

            return tblInfo.OrderBy(i => i.infoID).ToList();
            
        }
        public List<Files> getAllFiles() {

            return tblFiles.OrderBy(f => f.fileID).ToList();
            
        }

        public SelectList justschools() {

            List<School> schoolData = tblSchool.Where(s => !s.schoolID.Equals(0)).OrderBy(s => s.schoolID).ToList();
            return new SelectList(schoolData, "schoolID", "schoolName");
            
        }

        public string uploadResult(int result) {
            string uploadResult = "";
            if (result == 0) {
                uploadResult = "No file was found";
            } else if (result == 1) {
                uploadResult = "File type not permitted";
            } else if (result == 2) {
                uploadResult = "File exceeds the size limit";
            } else if (result == 3) {
                uploadResult = "File name must be under 100 characters";
            } else if (result == 4) {
                uploadResult = "Error occurred in saving the file";
            } else if (result == 5) {
                uploadResult = "Quote has been successfully added";
            }
            return uploadResult;   
        }

        // -------------------------------------------------- private methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8, 0, 11)));
        }

    }
}
