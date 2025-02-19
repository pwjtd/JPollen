using JPollen.Constants;

namespace JPollen.Storage;

public class JRowStorage
{
    public JRowStorage()
    {
        Values = new Dictionary<JRowType, List<object>>();
        Values.Add(JRowType.Value, new List<object>());
        Values.Add(JRowType.Array, new List<object>());
        Values.Add(JRowType.Object, new List<object>());
        Rows = new List<JRow>();
    }   
    public Dictionary<JRowType, List<object>> Values { get; private set; }
    public List<JRow> Rows { get; private set; }
    
    public string RegisterRow(string key, object value, JRowType rowType)
    { 
        if (!Values[rowType].Contains(value))
        {
            Values[rowType].Add(value);
        }

        if (rowType == JRowType.Object)
        {
            Console.WriteLine($"[{rowType.ToString().ToUpper()}{Values[rowType].IndexOf(value).ToString()}]");
            Console.WriteLine(value);
            Console.WriteLine(Values[rowType].IndexOf(value).ToString());
        }
        var signature = $"[{rowType.ToString().ToUpper()}{Values[rowType].IndexOf(value).ToString()}]";
        var existedRow = GetRowBySignature(signature);
        if (existedRow == null)
        {
            var row = new JRow();
            row.Key = key;
            row.Value = value;
            row.Type = rowType;
            row.Signature = signature;
            Rows.Add(row);
        }

        return signature;
    }

    public JRow GetRootRow()
    {
        return Rows.SingleOrDefault(x => x.Key == JPollenConstants.RootRow);
    }

    public JRow? GetRowBySignature(string signature)
    {
        return Rows.SingleOrDefault(x => x.Signature == signature);
    }
}