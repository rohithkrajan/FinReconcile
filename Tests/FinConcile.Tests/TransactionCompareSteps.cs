using FinConcile.Tests.Properties;
using FinConcile.Tests.TestUtils;
using FinReconcile.Controllers;
using FinReconcile.Core.Engines;
using FinReconcile.Infra;
using FinReconcile.Infra.Parsers;
using FinReconcile.Infra.Providers;
using FinReconcile.Models;
using Moq;
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
        HttpPostedFileBase _clientMarkOffFile, _bankMarkOffFile;

        Mock<IMarkOffFileProvider> _mockMarkOffFileProvider;
        IMarkOffFileParser _csvReader;
        Mock<IReconcileEngine> _mockReconcileEngine;
        const string ClientMarkoffFileName = "ClientMarkoffFile20140113";
        const string BankMarkoffFileName = "BankMarkoffFile20140113";
        string _sessionId;

        [BeforeScenario]
        public void InitScenario()
        {
            _mockMarkOffFileProvider = new Mock<IMarkOffFileProvider>();
            _mockReconcileEngine = new Mock<IReconcileEngine>();
            _csvReader = new CSVMarkOffFileParser();
            _sessionId = SessionIdGenerator.CreateNewId();
            _mockMarkOffFileProvider.Setup(x => x.SaveMarkOffFile(It.IsAny<Stream>(),_sessionId, ClientMarkoffFileName)).Returns(ClientMarkoffFileName);
            _mockMarkOffFileProvider.Setup(x => x.SaveMarkOffFile(It.IsAny<Stream>(),_sessionId, BankMarkoffFileName)).Returns(BankMarkoffFileName);

            _mockMarkOffFileProvider.Setup(x=>x.GetMarkOffFile(_sessionId,ClientMarkoffFileName)).Returns(Resources.ClientMarkoffFile20140113);
            _mockMarkOffFileProvider.Setup(x => x.GetMarkOffFile(_sessionId, BankMarkoffFileName)).Returns(Resources.BankMarkoffFile20140113);
        }

        [When(@"the user goes to compare user screen")]
        public void WhenTheUserGoesToCompareUserScreen()
        {
            _controller = new TransactionController(_mockMarkOffFileProvider.Object,_csvReader, _mockReconcileEngine.Object);
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

        [Given(@"ClientMarkOffFile and BankMarkOffFile")]
        public void GivenClientMarkOffFileAndBankMarkOffFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            //read the file from assembly resource and convert to http posted file
            _clientMarkOffFile = Utilities.GetMockHttpPostedFile(Resources.ClientMarkoffFile20140113, ClientMarkoffFileName);
            _bankMarkOffFile = Utilities.GetMockHttpPostedFile(Resources.BankMarkoffFile20140113, BankMarkoffFileName);            
        }


        [When(@"the user clicks on the Compare button")]
        public void WhenTheUserClicksOnTheCompareButton()
        {
            _controller = new TransactionController(_mockMarkOffFileProvider.Object,_csvReader,_mockReconcileEngine.Object);
           _result= _controller.Compare( new CompareModel() { ClientMarkOffFile = _clientMarkOffFile, BankMarkOfffile = _bankMarkOffFile });
        }

        [Then(@"user should be redirected to compare result Page")]
        public void ThenUserShouldBeRedirectedToTheCompareResultPage()
        {
            Assert.IsInstanceOf<RedirectToRouteResult>(_result);
            Assert.IsNotEmpty(((RedirectToRouteResult)_result).RouteValues["sid"].ToString());
            Assert.AreEqual(ClientMarkoffFileName, ((RedirectToRouteResult)_result).RouteValues["cfn"].ToString());
            Assert.AreEqual(BankMarkoffFileName, ((RedirectToRouteResult)_result).RouteValues["tfn"].ToString());

        }

        [Then(@"Comparison Result should contain Both Names of the Files '(.*)' and '(.*)'")]
        public void ThenComparisonResultShouldContainBothNamesOfTheFilesAnd(string clientFileName, string bankFileName)
        {
            Assert.IsInstanceOf<RedirectToRouteResult>(_result);
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)_result;
            Assert.IsNotEmpty(redirectResult.RouteValues["sid"].ToString());
            Assert.AreEqual("compareresult", redirectResult.RouteValues["action"]);
            Assert.AreEqual(ClientMarkoffFileName, redirectResult.RouteValues["cfn"].ToString());
            Assert.AreEqual(BankMarkoffFileName, redirectResult.RouteValues["tfn"].ToString());
        }

        [Then(@"TotalRecords (.*)")]
        public void ThenTotalRecords(int totalRecords)
        {
            var model = (CompareResult)((ViewResult)_result).Model;
            Assert.AreEqual(totalRecords, model.TotalClientRecords+model.TotalBankRecords);
        }

        [Then(@"MatchingRecords (.*)")]
        public void ThenMatchingRecords(int matchingRecords)
        {
            var model = (CompareResult)((ViewResult)_result).Model;
            Assert.AreEqual(matchingRecords, model.MatchingClientRecords+model.MatchingBankRecords);
        }

        [Then(@"UnmatchedRecords (.*)")]
        public void ThenUnmatchedRecords(int unMatchedRecords)
        {
            var model = (CompareResult)((ViewResult)_result).Model;
            Assert.AreEqual(unMatchedRecords, model.UnmatchedClientRecords+model.UnmatchedTutkaRecords);
        }



    }
}
