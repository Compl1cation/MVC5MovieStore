using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC5MovieStore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC5MovieStore.Models
{
    public class File
    {
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}