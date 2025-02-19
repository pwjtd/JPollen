using JPollen.Models.Results;
using JPollen.Rules.Base;

namespace JPollen.Rules;

public class JSwapRule : JRule
{
    public JSwapRule()
    {

    }
    
    public JRule SwapKeys(Dictionary<string, string> keysToSwap)
    {
        return this;
    }
    public JRule SwapValues(Dictionary<string, string> valuesToSwap)
    {
        return this;
    }

    public override JRuleResult ExecuteRule()
    {
        throw new NotImplementedException();
    }
}