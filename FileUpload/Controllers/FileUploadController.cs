using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileUpload.Models;
using FileUpload.Business;
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
        public ActionResult FileUploadProcess(FileUploadVm model,FileUploadBusiness fileUploadBusiness)
        {
            fileUploadBusiness.UploadFile(model);
            return RedirectToAction("Index");
        }
        public FileContentResult FileDownload(int? id, FileUploadBusiness fileUploadBusiness)
        {
          var file=  fileUploadBusiness.SearchFile(id);
          return File(fileUploadBusiness.fileData(file), "text", fileUploadBusiness.fileName(file));
        }
    }
}