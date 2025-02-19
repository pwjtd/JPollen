using JPollen.Models.Results;

namespace JPollen.Rules;

public interface IJRule
{ 
    JRuleResult ExecuteRule();
}