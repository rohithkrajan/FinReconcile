using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinReconcile.RuleEngine
{
    public class Rule
    {
        public string SourceMember
        {
            get;
            set;
        }

        public string Operator
        {
            get;
            set;
        }

        public string TargetMember
        {
            get;
            set;
        }

        public Rule(string SourceMember, string Operator, string TargetMember)
        {
            this.SourceMember = SourceMember;
            this.Operator = Operator;
            this.TargetMember = TargetMember;
        }
    }
}