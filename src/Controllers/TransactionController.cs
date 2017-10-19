using FinReconcile.Models;
using FinReconcile.Providers;
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
        string _clientMarkOffFilePath, _tutukaMarkOffFilePath;
        private IMarkOffFileProvider _markOffFileProvider;

        public TransactionController(IMarkOffFileProvider markoffFileProvider)
        {
            _markOffFileProvider = markoffFileProvider;
        }
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
                string clientFileName = null, tutukaFileName = null, sessionId;
                if (clientMarkOffFile.ContentLength>0 && tutukaMarkOfffile.ContentLength > 0)
                {                    
                    clientFileName = Path.GetFileName(clientMarkOffFile.FileName);
                    sessionId = SessionIdGenerator.CreateNewId();
                    _markOffFileProvider.SaveMarkOffFile(clientMarkOffFile.InputStream, sessionId, clientFileName);
               
                    tutukaFileName = Path.GetFileName(tutukaMarkOfffile.FileName);
                    _markOffFileProvider.SaveMarkOffFile(tutukaMarkOfffile.InputStream, sessionId, tutukaFileName);
               
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