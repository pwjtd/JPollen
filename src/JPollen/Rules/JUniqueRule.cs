using JPollen.Models.Results;
using JPollen.Rules.Base;

namespace JPollen.Rules;

public class JUniqueRule : JRule
{
    public bool UniqueKeys { get; set; }
    public bool UniqueValues { get; set; }
    public bool UniqueArrays { get; set; }
    public bool UniqueObjects { get; set; }
    public override JRuleResult ExecuteRule()
    {
        throw new NotImplementedException();
    }
}