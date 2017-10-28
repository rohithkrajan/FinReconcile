using FinReconcile.Core.Engines;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinReconcile.Controllers
{
    public class RulesController : Controller
    {
        public IReconcileEngine _reconcileEngine;

        public RulesController(IReconcileEngine reconcileEngine)
        {
            _reconcileEngine = reconcileEngine;
        }
        // GET: Rules
        public ActionResult Index()
        {
            Dictionary<string, string> rules = new Dictionary<string, string>();
            foreach (var item in _reconcileEngine.RuleEvaluators)
            {
                rules.Add(item.RuleName, JsonConvert.SerializeObject(item.RuleSet));
            }
            return View(rules);
        }
    }
}