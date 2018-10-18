using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileUpload.Models;
namespace FileUpload.Controllers
{
    public class FileUploadController : Controller
    {
        private FileUploadContext db = new FileUploadContext();
        // GET: FileUpload
        public ActionResult Index()
        {
            List<FileUploadModel> fileUp = db.fileUploadModel.ToList();
            return View(fileUp);
        }
        public ActionResult FileUploadProcess()
        {
            var model = new FileUploadVm();
            return View(model);
        }
        [HttpPost]
        public ActionResult FileUploadProcess(FileUploadVm model)
        {
            FileUploadModel fileUpload = new FileUploadModel();
            byte[] uploadFile = new byte[model.File.InputStream.Length];
            model.File.InputStream.Read(uploadFile, 0, uploadFile.Length);
            fileUpload.FileName = model.File.FileName;
            fileUpload.File = uploadFile;
            db.fileUploadModel.Add(fileUpload);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public FileContentResult FileDownload(int? id)
        {
            byte[] fileData;
            string fileName;

            FileUploadModel fileRecord = db.fileUploadModel.Find(id);
            fileData = (byte[])fileRecord.File.ToArray();
            fileName = fileRecord.FileName;
            return File(fileData, "text", fileName);
        }
    }
}