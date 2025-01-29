using JPollen.Models.Results;
using JPollen.Processing;
using JPollen.Rules;

namespace JPollen.Contexts;

public class JContext
{
    public string Name { get; set; }
    private List<JRule> Rules { get; set; }
    
    public JContext Swap(Action<JSwapRule> setSwapRule)
    {
        var swapRule = new JSwapRule();
        setSwapRule(swapRule);
        Rules.Add(swapRule);
        return this;
    }
    
    public JContext Skip(Action<JSkipRule> setSkipRule)
    {
        var skipRule = new JSkipRule();
        setSkipRule(skipRule);
        Rules.Add(skipRule);
        return this;
    }

    public JContextResult Execute(JCollection jCollection)
    {
        foreach (var rule in Rules)
        {
            rule.ExecuteRule();
        }

        return new JContextResult();
    }
}