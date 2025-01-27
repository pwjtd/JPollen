using System.Text.Json;
namespace JPollen.Processing;

public class CollectedJson
{
    public CollectedJson()
    {
        
    }
    public string ReleaseJson()
    {
        return "";
    }
    public MemoryStream ReleaseJsonAsStream()
    {
        var memoryStream = new MemoryStream();
        using var writer = new Utf8JsonWriter(memoryStream, new JsonWriterOptions { Indented = true });
        {
            
        }
        memoryStream.Position = 0;
        return memoryStream;
    }
}