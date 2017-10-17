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
            return View();
        }
        [HttpPost]
        public ActionResult Compare(HttpPostedFile clientMarkOffFile,HttpPostedFile tutukaMarkOfffile)
        {
            try
            {
                if (clientMarkOffFile.ContentLength>0)
                {
                    clientMarkOffFilePath = Path.Combine(Server.MapPath("~/Uploads"), Guid.NewGuid().ToString(), Path.GetFileName(clientMarkOffFile.FileName));
                    clientMarkOffFile.SaveAs(clientMarkOffFilePath);
                }
                if (tutukaMarkOfffile.ContentLength > 0)
                {
                    tutukaMarkOffFilePath = Path.Combine(Server.MapPath("~/Uploads"), Guid.NewGuid().ToString(), Path.GetFileName(tutukaMarkOfffile.FileName));
                    tutukaMarkOfffile.SaveAs(tutukaMarkOffFilePath);
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