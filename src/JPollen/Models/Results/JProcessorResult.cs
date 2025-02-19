using JPollen.Models.Results.Base;

namespace JPollen.Models.Results;

public class JProcessorResult : JResult
{
    public IEnumerable<JContextResult> ContextResults { get; set; }
}