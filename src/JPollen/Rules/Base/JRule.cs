using JPollen.Models.Results;

namespace JPollen.Rules.Base;

public abstract class JRule : IJRule
{
    public JRule()
    {

    }
    public int Order { get; set; }
    public abstract JRuleResult ExecuteRule();
}