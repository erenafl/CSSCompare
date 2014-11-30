using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class StylesheetComparer
    {
        private StylesheetAnalyzer StyleSheetAnalyzer;
        private CSSDocument Stylesheet1 { set; get; }
        private CSSDocument Stylesheet2 { set; get; }
        public double RulesetSimilarity { get; private set; }
        public double AtRuleSimilarity { get; private set; }
        private int RulesetAnalyzingChoice;
        private int StylesheetAnalyzingChoice;
        public StylesheetComparer(CSSDocument css1, CSSDocument css2, int choice1, int choice2)
        {
            Stylesheet1 = css1;
            Stylesheet2 = css2;
            RulesetAnalyzingChoice = choice1;
            StylesheetAnalyzingChoice = choice2;
            StyleSheetAnalyzer = new StylesheetAnalyzer(RulesetAnalyzingChoice);
        }
        public void Analyze()
        {
            StyleSheetAnalyzer.AnalyzeRulesets(Stylesheet1.rulesets, Stylesheet2.rulesets);
            StyleSheetAnalyzer.AnalyzeAtRules(Stylesheet1.atrules, Stylesheet2.atrules);
            CalculateSimilarities();
        }
        private void CalculateSimilarities()
        {
            CalculateRulesetSimilarity();
            CalculateAtRuleSimilarity();
        }
        private void CalculateRulesetSimilarity()
        {
            var NumberOfDistinctRulesets = Stylesheet1.rulesets.Count() + Stylesheet2.rulesets.Count() - StyleSheetAnalyzer.NumberOfCommonRulesets;
            var NumberOfAllElements = Stylesheet1.rulesets.Count() + Stylesheet2.rulesets.Count();
            if (NumberOfDistinctRulesets == 0) RulesetSimilarity = Convert.ToDouble(0);
            else
            {
                if (StylesheetAnalyzingChoice == 1)
                {
                    RulesetSimilarity = StyleSheetAnalyzer.TotalRulesetSimilarity / (Convert.ToDouble(NumberOfDistinctRulesets));
                }
                if (StylesheetAnalyzingChoice == 2)
                {
                    RulesetSimilarity = StyleSheetAnalyzer.TotalRulesetSimilarity / (Convert.ToDouble(NumberOfAllElements));
                }
            }
               
        }
        private void CalculateAtRuleSimilarity()
        {

        }
    }
}
