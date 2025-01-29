using JPollen.Storage;

namespace JPollen.Processing;

public class JCollection
{
    public JCollection()
    {
        ValueStorage = new JValueStorage();
        KeyStorage = new JKeyStorage();
    }
    
    public string Root { get; internal set; }
    public string Scheme { get; private set; }
    public JValueStorage ValueStorage { get; private set; }
    public JKeyStorage KeyStorage { get; private set; }
}