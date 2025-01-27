using JPollen.Processing;

namespace Example1;

class Program
{
    static void Main(string[] args)
    {
        string json1 = "{\"Name\": \"John\", \"Age\": 30}";
        string json2 = "[{\"Name\": \"John\", \"Age\": 30}, {\"Name\": \"Alice\", \"Age\": 25}]";
        var jsonCollector = new JsonCollector();
        var result1 = jsonCollector.CollectJson(json1);
        var result2 = jsonCollector.CollectJson(json2);
        string jsonTest = ConstantJsons.TestJson;
    }
    
    
    
}