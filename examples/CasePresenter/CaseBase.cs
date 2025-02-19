namespace CasePresenter;

public class CaseBase
{
    public string Title { get; set; }
    public string Description { get; set; }

    public virtual void Run() {}
}