using FinConcile.Tests.Properties;
using FinConcile.Tests.TestUtils;
using FinReconcile.Controllers;
using FinReconcile.Models;
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

        [Then(@"user should be shown compare result Page")]
        public void ThenUserShouldBeRedirectedToTheCompareResultPage()
        {
            Assert.IsInstanceOf<ViewResult>(_result);
            Assert.AreEqual("CompareResult", ((ViewResult)_result).ViewName);
            
        }

        [Then(@"Comparison Result should contain Both Names of the Files '(.*)' and '(.*)'")]
        public void ThenComparisonResultShouldContainBothNamesOfTheFilesAnd(string clientFileName, string tutukaFileName)
        {
            var model = (CompareResult)((ViewResult)_result).Model;
            Assert.AreEqual(clientFileName, model.ClientMarkOffFile);
            Assert.AreEqual(tutukaFileName, model.TutukaMarkOffFile);
        }

        [Then(@"TotalRecords (.*)")]
        public void ThenTotalRecords(int totalRecords)
        {
            var model = (CompareResult)((ViewResult)_result).Model;
            Assert.AreEqual(totalRecords, model.TotalRecords);
        }

        [Then(@"MatchingRecords (.*)")]
        public void ThenMatchingRecords(int matchingRecords)
        {
            var model = (CompareResult)((ViewResult)_result).Model;
            Assert.AreEqual(matchingRecords, model.MatchingRecords);
        }

        [Then(@"UnmatchedRecords (.*)")]
        public void ThenUnmatchedRecords(int unMatchedRecords)
        {
            var model = (CompareResult)((ViewResult)_result).Model;
            Assert.AreEqual(unMatchedRecords, model.UnmatchedRecords);
        }



    }
}
