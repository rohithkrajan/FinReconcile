using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.RuleEngine
{
    public class RuleSet
    {
        private IList<Rule> _rules;

        public RuleSet(IEnumerable<Rule> rules)
        {
            _rules = new List<Rule>();
            foreach (var item in rules)
            {
                _rules.Add(item);
            }
        }
        public IList<Rule> Rules { get { return _rules; }  }
    }
}