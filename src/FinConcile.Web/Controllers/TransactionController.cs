using FinReconcile.Core.Domain.Interfaces;
using FinReconcile.Core.Engines;
using FinReconcile.Infra;
using FinReconcile.Infra.Parsers;
using FinReconcile.Infra.Providers;
using FinReconcile.Models;
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
        public ActionResult Compare(CompareModel compareFiles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string clientFileName = null, bankFileName = null, sessionId;
                    if (compareFiles.ClientMarkOffFile.ContentLength > 0 && compareFiles.BankMarkOfffile.ContentLength > 0)
                    {
                        clientFileName = Path.GetFileName(compareFiles.ClientMarkOffFile.FileName);
                        sessionId = SessionIdGenerator.CreateNewId();

                        
                        ParserResult result = _csvFileReader.Validate(compareFiles.ClientMarkOffFile.InputStream);
                        if (!result.IsValid)
                        {
                            ModelState.AddModelError("ClientMarkOffFile", result.Errors[1]);
                            return View();
                        }
                        else
                        {
                            _markOffFileProvider.SaveMarkOffFile(compareFiles.ClientMarkOffFile.InputStream, sessionId, clientFileName);
                        }
                         
                         result = _csvFileReader.Validate(compareFiles.BankMarkOfffile.InputStream);
                        if (!result.IsValid)
                        {
                            ModelState.AddModelError("BankMarkOfffile", result.Errors[1]);
                            return View();
                        }
                        else
                        {
                            bankFileName = Path.GetFileName(compareFiles.BankMarkOfffile.FileName);
                            _markOffFileProvider.SaveMarkOffFile(compareFiles.BankMarkOfffile.InputStream, sessionId, bankFileName);
                        }                        
                        return RedirectToAction("compareresult", new { sid = sessionId, cfn = clientFileName, tfn = bankFileName });
                    }
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
        public ActionResult CompareResult(string sid,string cfn,string tfn)
        {
            var clientTransactions = _csvFileReader.GetRecords(_markOffFileProvider.GetMarkOffFile(sid, cfn));
            var bankTransactions = _csvFileReader.GetRecords(_markOffFileProvider.GetMarkOffFile(sid, tfn));
            IReconcileResult result = _reconcileEngine.Reconcile(clientTransactions, bankTransactions);            
            CompareResult model = new CompareResult(cfn, tfn,result);
            ViewBag.Title = "Compare Files Result";
            return View("CompareResult", model);
        }

        [HttpGet]
        [Route("transaction/unmatchedreport", Name = "unmatchedreport")]
        public ActionResult UnmatchedReport(string sid, string cfn, string tfn)
        {
            var clientTransactions = _csvFileReader.GetRecords(_markOffFileProvider.GetMarkOffFile(sid, cfn));
            var bankTransactions = _csvFileReader.GetRecords(_markOffFileProvider.GetMarkOffFile(sid, tfn));
            IReconcileResult result = _reconcileEngine.Reconcile(clientTransactions, bankTransactions);
            CompareResult model = new CompareResult(cfn, tfn, result);
            ViewBag.Title = "Compare Files Result";
            return View("UnmatchedReport", model);
        }
    }
}