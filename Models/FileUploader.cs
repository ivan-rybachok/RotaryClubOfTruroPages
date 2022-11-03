using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace RotaryClubOfTruro.Models {
    public class FileUploader {
        // class constants for upload errors
        public const int ERROR_NO_FILE = 0;
        public const int ERROR_TYPE = 1;
        public const int ERROR_SIZE = 2;
        public const int ERROR_NAME_LENGTH = 3;
        public const int ERROR_SAVE = 4;
        public const int SUCCESS = 5;
        // file size limit in bytes for IFormFile approach
        private const int UPLOADLIMIT = 4194304;
        // path to web app location
        private string targetFolder;
        // path to upload folder
        private string fullPath;
        // property variables
        private List<string> _fileSources;

        public FileUploader(IWebHostEnvironment env, string myTargetFolder) {
            // initialization
            targetFolder = myTargetFolder;
             _fileSources = new List<string>();
            // check to see if root folder of web app has an "uploads" folder
            fullPath = env.WebRootPath + "/" + targetFolder + "/";
            // if "uploads" folder does not exist, create it
            if (!Directory.Exists(fullPath)) {
                Directory.CreateDirectory(fullPath);
            }
        }
        // --------------------------------------------------- get/sets
        // this will be the value for file field in database
        public string fileName {get; set;}

        public string fileName1 {get; set;}
        
        // // --------------------------------------------------- public methods
        public int uploadFile(IFormFile file) {
            // error check 1 : no file is found
            if (file != null) {
                // error check 2 : check file type (ext)
                string contentType = file.ContentType;
                if ((contentType == "application/pdf") || (contentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") || (contentType == "application/msword")) {
                    // error check 3 : check file size is below upload limit
                    long size = file.Length;
                    if ((size > 0) && (size < UPLOADLIMIT)) {
                        // error check 4 : check to make sure the filename is under 100 characters
                        string filename = Path.GetFileName(file.FileName);
                        if (filename.Length <= 100) {
                            // image is okay, save the file to the server
                            // if filename exists, create a unique filename to prevent overwriting
                            if (File.Exists(fullPath + filename)) {
                                filename =  Guid.NewGuid().ToString() + filename;
                                }
                            // set to filename for image field in database
                            fileName = filename;
                            // fileName1 = filename;
                            FileStream stream = new FileStream((fullPath + filename), FileMode.Create);
                            try {
                                // copy the IFormFile object to the stream which writes it to the File System
                                file.CopyTo(stream);
                                stream.Close();
                                return FileUploader.SUCCESS;
                            } catch {
                                stream.Close();
                                return FileUploader.ERROR_SAVE;
                            }
                        } else {
                            return FileUploader.ERROR_NAME_LENGTH;
                        }
                    } else {
                        return FileUploader.ERROR_SIZE;
                    }
                } else {
                    return FileUploader.ERROR_TYPE;
                }
            } else {
                return FileUploader.ERROR_NO_FILE;
            }
        }
        public void deleteFile(string file) {
            // get the files and full path in myTargetFolder
            string[] fileArray = Directory.GetFiles(fullPath, "*.*");
            // remove full path, store it as a relative URL
            for (int i=0; i<fileArray.Length; i++) {
                _fileSources.Add("/" + targetFolder + "/" + Path.GetFileName(fileArray[i]));
            }
            // check to see if selected file is in folder
            if (_fileSources.Contains("/" + targetFolder + "/" + file)) {
                // delete the file
                File.Delete(fullPath+file);
                Console.WriteLine(fullPath+file);
            }
        }

    }
}