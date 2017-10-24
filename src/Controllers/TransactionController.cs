using FinReconcile.Domain.Interfaces;
using FinReconcile.MarkOffReader;
using FinReconcile.Models;
using FinReconcile.Providers;
using FinReconcile.ReconcileEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinReconcile.Controllers
{
    [RoutePrefix("transaction")]
    public class TransactionController : Controller
    {        
        private IMarkOffFileProvider _markOffFileProvider;
        private IMarkOffFileParser _csvFileReader;
        private IReconcileEngine _reconcileEngine;
        public TransactionController(IMarkOffFileProvider markoffFileProvider, IMarkOffFileParser csvFileReader, IReconcileEngine reconcileEngine)
        {
            _markOffFileProvider = markoffFileProvider;
            _csvFileReader = csvFileReader;
            _reconcileEngine = reconcileEngine;
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
                    return RedirectToAction("compareresult", new { sessionId = sessionId, clientFileName = clientFileName, tutukaFileName = tutukaFileName });
                }

                return View();
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("transaction/{sessionid}/compareresult",Name ="compareresult")]
        public ActionResult CompareResult(string sessionId,string clientFileName,string tutukaFileName)
        {
            var clientTransactions = _csvFileReader.GetRecords(_markOffFileProvider.GetMarkOffFile(sessionId, clientFileName));
            var tutukaTransactions = _csvFileReader.GetRecords(_markOffFileProvider.GetMarkOffFile(sessionId, tutukaFileName));

            IReconcileResult result = _reconcileEngine.Reconcile(clientTransactions, tutukaTransactions);

            
            CompareResult model = new CompareResult(clientFileName, tutukaFileName,result);
            ViewBag.Title = "Compare Files Result";
            return View("CompareResult", model);
        }
    }
}