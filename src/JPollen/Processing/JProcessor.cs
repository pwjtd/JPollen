using System.Text.Json.Nodes;
using JPollen.Models.Enums;
using JPollen.Models.Results;

namespace JPollen.Processing;

public sealed class JProcessor
{
    public JProcessor()
    {
        Configuration = new JProcessorConfiguration();
    }

    #region Configuration
    
    private JProcessorConfiguration Configuration { get; set; }

    public JProcessor Configure(Action<JProcessorConfiguration> configure)
    {
        configure(Configuration);
        return this;
    }
    public JResult RemoveContext(string contextName)
    {
        return Configuration.RemoveContext(contextName);
    }

    #endregion
    
    #region Processing
    public JProcessorResult FoldJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return new JProcessorResult { IsSuccess = false, Message = "Invalid JSON" };
        }
        
        JsonNode? jsonNode = JsonNode.Parse(json);
        if (jsonNode == null)
        {
            return new JProcessorResult { IsSuccess = false, Message = "Invalid JSON" };
        }

        CollectJson(jsonNode);
        // folding json to scheme

        return new JProcessorResult { IsSuccess = true  };
    }

    private JCollection CollectJson(JsonNode? jsonNode)
    {
        var collectedJson = new JCollection();
        collectedJson.Root = ExtractKeysAndValues(jsonNode, collectedJson);
        return collectedJson;
    }
    
    private string ExtractKeysAndValues(JsonNode? node, JCollection jCollection)
    {
        if (node == null)
        {
            return jCollection.ValueStorage.AddValueAndReturnSignature(JSourceType.Val, "null");
        }
        if (node is JsonObject obj)
        {
            var objValues = new List<string>();
            foreach (var param in obj)
            {
                var value = ExtractKeysAndValues(param.Value, jCollection);
                objValues.Add(value);
            }
            var objValueAsString = $"[{string.Join(",", objValues)}]";
            return jCollection.ValueStorage.AddValueAndReturnSignature(JSourceType.Obj, objValueAsString);
        }
        
        if (node is JsonArray array)
        {
            var arrValues = new List<string>();
            foreach (var param in array)
            {
                var value = ExtractKeysAndValues(param, jCollection);
                arrValues.Add(value);
            }
            var arrValueAsString = $"[{string.Join(",", arrValues)}]";
            return jCollection.ValueStorage.AddValueAndReturnSignature(JSourceType.Arr, arrValueAsString);
        }
        
        if (node is JsonValue valueNode)
        {
            return jCollection.ValueStorage.AddValueAndReturnSignature(JSourceType.Val, valueNode.ToString());
        }
        
        return string.Empty;
    }
    
    #endregion
}