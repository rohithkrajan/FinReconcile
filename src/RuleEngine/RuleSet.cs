using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.RuleEngine
{
    public class RuleSet
    {
        private IList<IRule> _rules;

        public RuleSet(IEnumerable<IRule> rules)
        {
            _rules = new List<IRule>();
            foreach (var item in rules)
            {
                _rules.Add(item);
            }
        }
        public IList<IRule> Rules { get { return _rules; }  }
    }
}