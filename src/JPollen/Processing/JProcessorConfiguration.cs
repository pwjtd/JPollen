namespace JPollen.Processing;

public class JProcessorConfiguration
{
    internal List<JContext> Contexts { get; private set; } = new();
    
    public JProcessorConfiguration AddContext(Action<JContext> setContext)
    {
        var context = new JContext();
        setContext(context);
        if (Contexts.Any(x => x.Name == context.Name))
        {
            throw new Exception("Context with this name already exists");
        }
        Contexts.Add(context);
        return this;
    }
}