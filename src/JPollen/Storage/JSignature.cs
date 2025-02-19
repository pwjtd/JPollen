namespace JPollen.Storage;

public readonly record struct JSignature
{
    private readonly string _value;

    public JSignature(JRowType rowType, int index) => _value = $"{rowType}{index}";

    public override string ToString() => _value;

    public static explicit operator string(JSignature signature) => signature._value;
}