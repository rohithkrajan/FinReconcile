using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.RuleEngine
{
    public class RuleSet
    {
        private IList<IRule> _rules= new List<IRule>();

        public RuleSet()
        {
        }
        public RuleSet(IEnumerable<IRule> rules)
        {
            
            foreach (var item in rules)
            {
                _rules.Add(item);
            }
        }
        public IList<IRule> Rules { get { return _rules; }  }
    }
}