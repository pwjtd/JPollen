namespace JPollen.Models.Results.Base;

public abstract class JResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}   