using JPollen.Processing;

namespace CasePresenter;

public class FoldJsonToSchemeCase : CaseBase
{
    public FoldJsonToSchemeCase()
    {
        Title = "Fold JSON to scheme Case";
    }
    public override void Run()
    {
        var json = ExampleJsons.FoldJsonCaseJson();
        var processor = new JProcessor()
            .Configure(x =>
            {
                x.AddContext(c =>
                {
                    c.Name = "Simple fold";
                });
            });
        var result = processor.Run(json);
        //var releasedJson = processor.ReleaseJson(result.JCollection, false);
        
        Console.WriteLine("=============================================================");
       // Console.WriteLine(releasedJson);
        
      //  var releasedJsonAsSignatures = processor.ReleaseJson(result.JCollection, true);
        
        Console.WriteLine("=============================================================");
      //4  Console.WriteLine(releasedJsonAsSignatures);
    }
}