namespace JPollen.Storage;

public class JRow
{
    public string Key { get; set; }
    public object Value { get; set; }
    public JRowType Type { get; set; }
    public string Signature { get; set; }
    public int Length { get; set; }
}