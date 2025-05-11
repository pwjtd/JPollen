using JPollen.UnitTests.JsonExamples;

namespace JPollen.UnitTests;

public class UnitTest1
{
    [Fact]
    public void Collect_Json_Test()
    {
        string personJson = ConstantJsonStrings.Person;
        JsonCollector jsonCollector = new();
        
        var store = jsonCollector.Collect(personJson);
        
        Assert.NotNull(store);
    }
    
    [Fact]
    public void Release_Json_Store()
    {
        string personJson = ConstantJsonStrings.Person;
        JsonCollector jsonCollector = new();
        JsonReleaser jsonReleaser = new();
        var store = jsonCollector.Collect(personJson);
        
        string releasedJson = jsonReleaser.Release(store);
        
        Assert.Equal(ConstantJsonStrings.Person, releasedJson);
    }
}