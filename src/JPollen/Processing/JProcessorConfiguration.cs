using JPollen.Contexts;
using JPollen.Models.Results;

namespace JPollen.Processing;

public class JProcessorConfiguration
{
    private List<JContext> Contexts { get; set; } = new();
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
    internal JResult RemoveContext(string contextName)
    {
        var contextToRemove = Contexts.SingleOrDefault(x=>x.Name == contextName);
        if (contextToRemove == null)
        {
            return new JResult { IsSuccess = false, Message = "Context with this name does not exist" };
        }
        return new JResult { IsSuccess = true };
    }
}