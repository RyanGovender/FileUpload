using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace FileUpload.Models
{
    public class FileUploadVm
    {
        [Key]
        public int key { get; set; }
        [DisplayName("Select File to Upload")]
        public HttpPostedFileBase File { get; set; }
        [Display(Name = "File Name")]
        [Required]
        public string FileName { get; set; }
    }
}