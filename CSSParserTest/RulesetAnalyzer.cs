using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class RulesetAnalyzer
    {
        private Ruleset FirstRuleset {  set; get; }
        private Ruleset SecondRuleset {  set; get; }
        public bool IsCommon { private set; get; }
        private int NumberOfCommonProperties {  set;  get; }
        private int NumberOfDistinctProperties {  set;  get; }
        public RulesetAnalyzer()
        {
            
        }
        public double AnalyzeRulesets(Ruleset first, Ruleset second)
        {
            IsCommon = false;
            FirstRuleset = first;
            SecondRuleset = second;
            return CalculateSimilarity();

        }
        private void AnalyzeSelector() 
        {
            if(FirstRuleset.selector.value == SecondRuleset.selector.value)
            {
                IsCommon = true;
                AnalyzeProperties();
            }
        }
        private void AnalyzeProperties()
        {
            var firstProperties = (from decleration in FirstRuleset.declerations select decleration.property.value).ToList();
            var secondProperties = (from decleration in SecondRuleset.declerations select decleration.property.value).ToList();
            NumberOfCommonProperties = firstProperties.Intersect(secondProperties).Count();
            NumberOfDistinctProperties = firstProperties.Count() + secondProperties.Count() - NumberOfCommonProperties;
        }
        private double CalculateSimilarity()
        {
            AnalyzeSelector();
            
            if(IsCommon) 
            {
                if (NumberOfDistinctProperties == 0 && NumberOfCommonProperties == 0) return Convert.ToDouble(1);
                return Convert.ToDouble(NumberOfCommonProperties) / Convert.ToDouble(NumberOfDistinctProperties);
            }
            return Convert.ToDouble(0);
        }
    }
}
