using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.RuleEngine
{
    public class RuleSet
    {
        private IEnumerable<Rule> _rules;

        public RuleSet(IEnumerable<Rule> rules)
        {
            _rules = rules;
        }
        public IEnumerable<Rule> Rules { get;  }
    }
}