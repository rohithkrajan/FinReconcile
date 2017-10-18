using FinReconcile.Controllers;
using NUnit.Framework;
using System;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace FinConcile.Tests
{
    [Binding]
    public class CompareTransactionsSteps
    {
        ActionResult _result;
        TransactionController _controller;

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
            Assert.IsEmpty(((ViewResult)_result).ViewName);
            Assert.AreEqual("Compare Files",
                   _controller.ViewData["Title"],
                   "Compare Files");
        }

    }
}
