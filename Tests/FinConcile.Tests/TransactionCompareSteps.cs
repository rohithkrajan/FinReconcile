using FinConcile.Tests.Properties;
using FinConcile.Tests.TestUtils;
using FinReconcile.Controllers;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace FinConcile.Tests
{
    [Binding]
    public class CompareTransactionsSteps
    {
        ActionResult _result;
        TransactionController _controller;
        HttpPostedFileBase _clientMarkOffFile, _tutukaMarkOffFile;
        [When(@"the user goes to compare user screen")]
        public void WhenTheUserGoesToCompareUserScreen()
        {
            _controller = new TransactionController();
            _result = _controller.Compare();
        }

        [Then(@"the compare user view should be displayed")]
        public void ThenTheCompareUserViewShouldBeDisplayed()
        {
            Assert.IsInstanceOf<ViewResult>(_result);            
            Assert.AreEqual("Compare Files",
                   _controller.ViewData["Title"],
                   "Compare Files");
        }

        [Given(@"ClientMarkOffFile and TutukaMarkOffFile")]
        public void GivenClientMarkOffFileAndTutukaMarkOffFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            //read the file from assembly resource and convert to http posted file
            _clientMarkOffFile = Utilities.GetMockHttpPostedFile(Resources.ClientMarkoffFile20140113,"ClientMarkoffFile20140113");
            _clientMarkOffFile = Utilities.GetMockHttpPostedFile(Resources.TutukaMarkoffFile20140113, "TutukaMarkoffFile20140113");            
        }


        [When(@"the user clicks on the Compare button")]
        public void WhenTheUserClicksOnTheCompareButton()
        {
            _controller = new TransactionController();
           _result= _controller.Compare(_clientMarkOffFile, _tutukaMarkOffFile);
        }

        [Then(@"user should be redirected to the compare result Page")]
        public void ThenUserShouldBeRedirectedToTheCompareResultPage()
        {
            Assert.IsInstanceOf<ViewResult>(_result);
            Assert.AreEqual("CompareResult", ((ViewResult)_result).ViewName);
            
        }


    }
}
