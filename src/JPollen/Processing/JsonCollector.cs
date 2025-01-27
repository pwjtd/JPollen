namespace JPollen.Processing;

public class JsonCollector
{
    public CollectedJson CollectJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return new CollectedJson();
        }
        
        
        
        
        return new CollectedJson();
    }
    
    
    
    
    
    public CollectedJson CollectJson(Stream jsonStream)
    {
        return new CollectedJson();
    }
}