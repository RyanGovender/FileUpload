using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FileUpload.Models
{
    public class FileUploadModel
    {
        [Key]
        public int FileId { get; set; }
        public byte[] File { get; set; }
        [Display(Name = "File Name")]
        public string FileName { get; set; }
    }
}