namespace JPollen.Rules;

public class JSwapRule : JRule
{
    public JSwapRule()
    {
        KeysToSwap = new Dictionary<string, string>();
        ValuesToSwap = new Dictionary<string, string>();
    }
    public Dictionary<string, string> KeysToSwap;
    public Dictionary<string, string> ValuesToSwap;
    
    public JRule SwapKeys(Dictionary<string, string> keysToSwap)
    {
        foreach (var kvp in keysToSwap)
        {
            KeysToSwap.TryAdd(kvp.Key, kvp.Value);
        }
        return this;
    }
    public JRule SwapValues(Dictionary<string, string> valuesToSwap)
    {
        foreach (var kvp in valuesToSwap)
        {
            ValuesToSwap.TryAdd(kvp.Key, kvp.Value);
        }
        return this;
    }

    public override void ExecuteRule()
    {
        throw new NotImplementedException();
    }
}