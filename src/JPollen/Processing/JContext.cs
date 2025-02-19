using JPollen.Models.Results;

namespace JPollen.Processing;

public class JContext
{
    public JContext()
    {
        Configuration = new JContextConfiguration();
    }
    public string Name { get; set; }
    public string Description { get; set; }
    private JContextConfiguration Configuration { get; set; }
    private JCollection JCollection { get; set; }
    
    public JContextResult Execute()
    {
        var results = new List<JRuleResult>();
        foreach (var rule in Configuration.Rules)
        {
            var ruleResult = rule.ExecuteRule();
            results.Add(ruleResult);
        }

        return new JContextResult ();
    }
}