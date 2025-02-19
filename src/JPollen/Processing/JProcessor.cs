using System.Text.Json;
using System.Text.Json.Nodes;
using JPollen.Constants;
using JPollen.Models.Results;
using JPollen.Storage;

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

    #endregion
    
    #region Processing

    public JProcessorResult Run(string json)
    
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

        var jCollection = CollectJson(jsonNode);
        ShowCurrentRowStorage(jCollection); // DH
        ShowCurrentKeyValues(jCollection); // DH
        
        var contextResults = new List<JContextResult>();
        foreach (var context in Configuration.Contexts)
        {
            var contextResult = context.Execute();
            contextResults.Add(contextResult);
        }

        return new JProcessorResult { ContextResults = contextResults };
    }
    
    public string ReleaseJson(JCollection jCollection, bool valuesAsSignature)
    {
        var root = jCollection.RowStorage.GetRootRow();
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });
        WriteRowsToJson(jCollection, root, writer, root.Type, valuesAsSignature);
        writer.Flush();
        return System.Text.Encoding.UTF8.GetString(stream.ToArray());
    }
    
    private JCollection CollectJson(JsonNode? jsonNode)
    {
        var jCollection = new JCollection();
        jCollection.Root = ExtractKeysAndValues(jsonNode,JPollenConstants.RootRow, jCollection);
        jCollection.Scheme = FoldJsonToScheme();
        return jCollection;
    }
    
    private string ExtractKeysAndValues(JsonNode? node, string key, JCollection jCollection)
    {
        if (node == null)
        {
            if (key == JPollenConstants.RootRow)
            {
                throw new Exception();
            }
            return jCollection.RowStorage.RegisterRow(key, null, JRowType.Value);
        }
        
        if (node is JsonObject obj)
        {
            var objValues = new List<string>();
            foreach (var param in obj)
            {
                var value = ExtractKeysAndValues(param.Value, param.Key, jCollection);
                objValues.Add(value);
            }
            return jCollection.RowStorage.RegisterRow(key, objValues, JRowType.Object);
        }
        
        if (node is JsonArray array)
        {
            var arrValues = new List<string>();
            foreach (var param in array)
            {
                var value = ExtractKeysAndValues(param, key, jCollection);
                arrValues.Add(value);
            }
            return jCollection.RowStorage.RegisterRow(key, arrValues, JRowType.Array);
        }
        
        if (node is JsonValue valueNode)
        {
            return jCollection.RowStorage.RegisterRow(key, valueNode.ToString(), JRowType.Value);
        }
        
        throw new Exception();
    }
    
    private void WriteRowsToJson(JCollection jCollection, JRow row, Utf8JsonWriter writer, JRowType parentRowType, bool valuesAsSignature)
    {
        try
        {
            if (row.Type == JRowType.Object)
            {
                if (row.Key == JPollenConstants.RootRow || parentRowType == JRowType.Array)
                {
                    writer.WriteStartObject();
                }
                else
                {
                    writer.WriteStartObject(row.Key);
                }

                var signatures = row.Value as List<string>;
                foreach (var signature in signatures)
                {
                    WriteRowsToJson(jCollection, jCollection.RowStorage.GetRowBySignature(signature), writer, JRowType.Object, valuesAsSignature);
                }
                writer.WriteEndObject();
                return;
            }

            if (row.Type == JRowType.Array)
            {
                if (row.Key == JPollenConstants.RootRow || parentRowType == JRowType.Array)
                {
                    writer.WriteStartArray();
                }
                else
                {
                    writer.WriteStartArray(row.Key);
                }

                var signatures = row.Value as List<string>;
                foreach (var signature in signatures)
                {
                    WriteRowsToJson(jCollection, jCollection.RowStorage.GetRowBySignature(signature), writer, JRowType.Array, valuesAsSignature);
                }
                writer.WriteEndArray();
                return;
            }

            if (parentRowType == JRowType.Array)
            {
                if (valuesAsSignature)
                {
                    writer.WriteStringValue(row.Signature);
                }
                else
                {
                    writer.WriteStringValue(row.Value as string);  
                }
            }

            if (parentRowType == JRowType.Object)
            {
                if (valuesAsSignature)
                {
                    writer.WriteString(row.Key, row.Signature);
                }
                else
                {
                    writer.WriteString(row.Key, row.Value as string);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private string FoldJsonToScheme()
    {
        return "";
    }
    
    #endregion

    #region DevHelpers

    public void ShowCurrentRowStorage(JCollection jCollection)
    {
        Console.WriteLine("====================ROW=STORAGE===============================");
        
        foreach (var row in jCollection.RowStorage.Rows)
        {
            if (row.Type == JRowType.Value)
            {
                Console.WriteLine($"{row.Signature}: {row.Key} - {row.Value}");
            }
            else
            {
                var rowValuesAsString = $"[{string.Join(",", row.Value as List<string>)}]";
                Console.WriteLine($"{row.Signature}: {row.Key} - {rowValuesAsString}");
            }
        }
        
        Console.WriteLine("=============================================================");
    }

    public void ShowCurrentKeyValues(JCollection jCollection)
    {
        Console.WriteLine("====================KEY=VALUES===============================");
        foreach (var valueDictionary in jCollection.RowStorage.Values)
        {
            Console.WriteLine(valueDictionary.Key);
            if (valueDictionary.Key == JRowType.Value)
            {
                foreach (var value in valueDictionary.Value)
                {
                    Console.WriteLine(value);
                }
            }
            else
            {
                foreach (var value in valueDictionary.Value)
                {
                    var rowValuesAsString = $"[{string.Join(",", value as List<string>)}]";
                    Console.WriteLine(rowValuesAsString);
                }
            }
        }
        Console.WriteLine("=============================================================");
    }

    #endregion
}