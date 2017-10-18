using FinReconcile.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinReconcile.Controllers
{
    public class TransactionController : Controller
    {
        string clientMarkOffFilePath, tutukaMarkOffFilePath;
        // GET: Transaction
        public ActionResult Compare()
        {
            ViewBag.Title = "Compare Files";
            return View();
        }
        [HttpPost]
        public ActionResult Compare(HttpPostedFileBase clientMarkOffFile,HttpPostedFileBase tutukaMarkOfffile)
        {
            try
            {
                string clientFileName=null, tutukaFileName=null;
                if (clientMarkOffFile.ContentLength>0)
                {
                    clientFileName = Path.GetFileName(clientMarkOffFile.FileName);
                    clientMarkOffFilePath = Path.Combine(Server.MapPath("~/Uploads"), Guid.NewGuid().ToString()+"_"+clientFileName);
                    clientMarkOffFile.SaveAs(clientMarkOffFilePath);
                }
                if (tutukaMarkOfffile.ContentLength > 0)
                {
                    tutukaFileName = Path.GetFileName(tutukaMarkOfffile.FileName);
                    tutukaMarkOffFilePath = Path.Combine(Server.MapPath("~/Uploads"), Guid.NewGuid().ToString() + "_" + tutukaFileName );
                    tutukaMarkOfffile.SaveAs(tutukaMarkOffFilePath);
                }
                if (!string.IsNullOrEmpty(clientFileName) && !string.IsNullOrEmpty(tutukaFileName))
                {
                    CompareResult model = new CompareResult(clientFileName, tutukaFileName);
                    ViewBag.Title = "Compare Files Result";
                    return View("CompareResult", model);
                }

                return View();
                
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}