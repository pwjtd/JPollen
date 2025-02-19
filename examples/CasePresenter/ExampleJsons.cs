using System.Text.Json;

namespace CasePresenter;

public static class ExampleJsons
{
    public static string FoldJsonCaseJson()
    {
         var jsonData = new Dictionary<string, object>
        {
            { "name", "John Doe" },
            { "email", "john.doe@example.com" },
            { "details", new Dictionary<string, object>
                {
                    { "name", "John Doe" },
                    { "address", "123 Main St" },
                    { "city", "Springfield" },
                    { "attributes", new List<object>
                        {
                            new Dictionary<string, object>
                            {
                                { "key", "color" },
                                { "value", "blue" }
                            },
                            new Dictionary<string, object>
                            {
                                { "key", "size" },
                                { "value", "large" }
                            }
                        }
                    }
                }
            },
            { "tags", new List<object> { "tag1", "tag2", "tag3" } },
            { "history", new List<object>
                {
                    new Dictionary<string, object>
                    {
                        { "date", "2024-02-16" },
                        { "event", "created" },
                        { "attributes", new List<object>
                        {
                            new Dictionary<string, object>
                            {
                                { "key", "color" },
                                { "value", "blue" }
                            },
                            new Dictionary<string, object>
                            {
                                { "key", "size" },
                                { "value", "large" }
                            }
                        }
                    }
                    },
                    new Dictionary<string, object>
                    {
                        { "date", "2024-02-17" },
                        { "event", "updated" },
                        { "attributes", new List<object>
                            {
                                new Dictionary<string, object>
                                {
                                    { "key", "color" },
                                    { "value", "blue" }
                                },
                                new Dictionary<string, object>
                                {
                                    { "key", "size" },
                                    { "value", "large" }
                                }
                            }
                        }
                    }
                }
            }
        };

        return JsonSerializer.Serialize(jsonData);
    }
}