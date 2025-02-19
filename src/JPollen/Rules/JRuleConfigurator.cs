using JPollen.Rules.Base;

namespace JPollen.Rules;

public class JRuleConfigurator
{
    public JRuleConfigurator()
    {
        Rules = new List<JRule>();
    }
    
    internal List<JRule> Rules { get; set; }
    public JRuleConfigurator Swap(Action<JSwapRule> setSwapRule)
    {
        var swapRule = new JSwapRule();
        setSwapRule(swapRule);
        Rules.Add(swapRule);
        return this;
    }
    
    public JRuleConfigurator Skip(Action<JSkipRule> setSkipRule)
    {
        var skipRule = new JSkipRule();
        setSkipRule(skipRule);
        Rules.Add(skipRule);
        return this;
    }

    public JRuleConfigurator Unique(Action<JUniqueRule> setUniqueRule)
    {
        var uniqueRule = new JUniqueRule();
        setUniqueRule(uniqueRule);
        Rules.Add(uniqueRule);
        return this;
    }

    public JRuleConfigurator Match(Action<JMatchRule> setMatchRule)
    {
        var matchRule = new JMatchRule();
        setMatchRule(matchRule);
        Rules.Add(matchRule);
        return this;
    }
}