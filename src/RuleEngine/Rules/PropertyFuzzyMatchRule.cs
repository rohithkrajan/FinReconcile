using FinReconcile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FinReconcile.RuleEngine.Rules
{
    public class FuzzyMatchParam
    {
        public string SourceProperty { get; set; }
        public string TargetProperty { get; set; }
        public int LevenshteinDistance { get; set; }
    }
    public class PropertyFuzzyMatchRule : MethodBaseRule<FuzzyMatchParam>
    {
        FuzzyMatchParam _factoryMethodParam;       

        public PropertyFuzzyMatchRule(string sourceProperty,string targetproperty,int levenshteinDistance) :base(FuzzyMatch)
        {
            _factoryMethodParam = new FuzzyMatchParam
            {
                SourceProperty=sourceProperty,
                TargetProperty=targetproperty,
                LevenshteinDistance= levenshteinDistance

            };           
        }        
        private static string GetValue(string propertyName, Transaction obj)
        {
            return (string)obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }
        public static bool FuzzyMatch(Transaction source, Transaction target, FuzzyMatchParam k)
        {
            string sourceValue = GetValue(k.SourceProperty, source);
            string targetValue = GetValue(k.SourceProperty, target);
            string text, pattern;
            int allowedIndex = 0;
            if (sourceValue.Length>=targetValue.Length)
            {
                text = sourceValue;
                pattern = targetValue;
            }
            else
            {
                pattern = sourceValue;
                text = targetValue;
            }
            int result = FuzzyMatchString(text,pattern , k.LevenshteinDistance);

            if (result<allowedIndex)
            {
                return true;
            }
            return false;
        }
        private static int FuzzyMatchString(string text, string pattern, int levenshteinDistance)
        {
            int result = -1;
            int m = pattern.Length;
            int[] R;
            int[] patternMask = new int[128];
            int i, d;

            if (string.IsNullOrEmpty(pattern)) return 0;
            if (m > 31) return -1; //Error: The pattern is too long!

            R = new int[(levenshteinDistance + 1) * sizeof(int)];
            for (i = 0; i <= levenshteinDistance; ++i)
                R[i] = ~1;

            for (i = 0; i <= 127; ++i)
                patternMask[i] = ~0;

            for (i = 0; i < m; ++i)
                patternMask[pattern[i]] &= ~(1 << i);

            for (i = 0; i < text.Length; ++i)
            {
                int oldRd1 = R[0];

                R[0] |= patternMask[text[i]];
                R[0] <<= 1;

                for (d = 1; d <= levenshteinDistance; ++d)
                {
                    int tmp = R[d];

                    R[d] = (oldRd1 & (R[d] | patternMask[text[i]])) << 1;
                    oldRd1 = tmp;
                }

                if (0 == (R[levenshteinDistance] & (1 << m)))
                {
                    result = (i - m) + 1;
                    break;
                }
            }

            return result;
        }
    }
}