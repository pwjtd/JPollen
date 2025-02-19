using JPollen.Storage;

namespace JPollen.Processing;

public class JCollection
{
    public JCollection()
    {
        RowStorage = new JRowStorage();
    }
    
    public string Root { get; internal set; }
    public string Scheme { get; internal set; }
    public JRowStorage RowStorage { get; internal set; }
}