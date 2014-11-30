using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class StylesheetAnalyzer
    {
        private RulesetAnalyzer RulesetComparer { set; get; }
        private AtRuleAnalyzer AtRuleComparer { get; set; }
        public int NumberOfCommonRulesets { private set; get; }
        public int NumberOfCommonAtRules { private set; get; }
        public double TotalRulesetSimilarity { private set; get; }
        public double TotalAtRuleSimilarity { private set; get; }
        private int RulesetAnalyzingChoice;
        public StylesheetAnalyzer(int choice)
        {
            NumberOfCommonRulesets = 0;
            NumberOfCommonAtRules = 0;
            TotalRulesetSimilarity = Convert.ToDouble(0);
            TotalAtRuleSimilarity = Convert.ToDouble(0);
            RulesetAnalyzingChoice = choice;
            RulesetComparer = new RulesetAnalyzer(RulesetAnalyzingChoice);
        }


        public void AnalyzeRulesets(List<Ruleset> rulesets1, List<Ruleset> rulesets2)
        {
            foreach(Ruleset ruleset1 in rulesets1)
            {
                foreach (Ruleset ruleset2 in rulesets2)
                {
                    TotalRulesetSimilarity += RulesetComparer.AnalyzeRulesets(ruleset1, ruleset2);
                    if (RulesetComparer.IsCommon) NumberOfCommonRulesets++;
                }
            }
        }

        public void AnalyzeAtRules(List<AtRule> atrules1, List<AtRule> atrules2) 
        {

        }
        /*
        public void Analyze()
        {
            AnalyzeRulesets();
            AnalyzeAtRules();
        }
        */

    }
}
