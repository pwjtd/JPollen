using JPollen.Models.Enums;

namespace JPollen.Storage;

public class JValueStorage
{
    public JValueStorage()
    {
        Values = new Dictionary<JSourceType, List<string>>();
        Values.Add(JSourceType.Val, new List<string>());
        Values.Add(JSourceType.Obj, new List<string>());
        Values.Add(JSourceType.Arr, new List<string>());
    }
    private Dictionary<JSourceType, List<string>> Values { get; set; }

    public string AddValueAndReturnSignature(JSourceType source, string key)
    {
        if (!Values[source].Contains(key))
        {
            Values[source].Add(key);
        }

        return $"[{source.ToString().ToUpper()}{Values[source].IndexOf(key).ToString()}]";
    }
}