using JPollen.Processing;

namespace Example1;

class Program
{
    static void Main(string[] args)
    {
        var translateDictionary = new Dictionary<string, string>()
        {
            {"One","Jeden"},
            {"Two","Dwa"},
            {"Three","Trzy"}
        };
        var replaceIdKeysToGuidDictionary = new Dictionary<string, string>()
        {
            {"Id","Guid"},
        };
        var replaceIdValuesToGuidDictionary = new Dictionary<string, string>()
        {
            {"2140","48F66EAB-3749-49A4-A169-AAA4E2788B98"},
        };
        var processor = new JProcessor()
            .Configure(x =>
                {
                    x.AddContext(c =>
                    {
                        c.Name = "Translate_EN_to_PL";
                        c.Swap(rule =>
                        {
                            rule.SwapValues(translateDictionary);
                        });
                    });
                    x.AddContext(c =>
                    {
                        c.Name = "Replace Id to GUID";
                        c.Swap(rule =>
                        {
                            rule.SwapKeys(replaceIdKeysToGuidDictionary);
                            rule.SwapValues(replaceIdValuesToGuidDictionary); // with filter
                        });
                    });
                });
        var foldedJson = processor.FoldJson("");
    }
}