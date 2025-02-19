using JPollen.Models.Results.Base;

namespace JPollen.Models.Results;

public class JContextResult : JResult
{
    public IEnumerable<JRuleResult> RuleResults { get; set; }
}