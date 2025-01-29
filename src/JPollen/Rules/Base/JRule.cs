namespace JPollen.Rules;

public abstract class JRule : IJRule
{
    public JRule()
    {

    }

    public abstract void ExecuteRule();
}