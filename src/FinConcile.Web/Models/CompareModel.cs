using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinReconcile.Models
{
    public class CompareModel
    {
        [Required(ErrorMessage ="Please provide mark off file")]
        public HttpPostedFileBase ClientMarkOffFile { get; set; }
        
        [Required(ErrorMessage = "Please provide mark off file")]
        public HttpPostedFileBase BankMarkOfffile { get; set; }
    }
}