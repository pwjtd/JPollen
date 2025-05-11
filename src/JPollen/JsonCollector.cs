using System.Text;
using System.Text.Json;

namespace JPollen;

public class JsonCollector
{
    public JsonStore Collect(string json)
    {
        var store = new JsonStore();
        Queue<Container> containers = new();
        Container currentContainer = new();
        string currentKey = string.Empty;
        
        byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
        var reader = new Utf8JsonReader(jsonBytes);

        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                // containers
                case JsonTokenType.StartObject:
                    var objContainer = new Container { Type = ContainerType.Object };
                    store.Containers.Add(objContainer);
                    currentContainer.AddItem(objContainer.Id, ItemType.Container, currentKey);
                    containers.Enqueue(currentContainer);
                    currentContainer = objContainer;
                    break;
                case JsonTokenType.EndObject:
                    currentContainer = containers.Dequeue();
                    break;
                case JsonTokenType.StartArray:
                    var arrayContainer = new Container { Type = ContainerType.Array };
                    store.Containers.Add(arrayContainer);
                    currentContainer.AddItem(arrayContainer.Id, ItemType.Container, null);
                    containers.Enqueue(currentContainer);
                    currentContainer = arrayContainer;
                    break;
                case JsonTokenType.EndArray:
                    currentContainer = containers.Dequeue();
                    break;
                
                // key
                case JsonTokenType.PropertyName:
                    string? key = reader.GetString();
                    currentKey = key ?? string.Empty;
                    break;
                
                // values
                case JsonTokenType.String:
                    string? stringValue = reader.GetString();
                    var stringParticle = new Particle { Value = stringValue, Type = ParticleType.String };
                    store.Particles.Add(stringParticle);
                    currentContainer.AddItem(stringParticle.Id, ItemType.Particle, currentKey);
                    break;
                
                case JsonTokenType.True:
                case JsonTokenType.False:
                    bool boolValue = reader.GetBoolean();
                    var boolParticle = new Particle { Value = boolValue, Type = ParticleType.Boolean };
                    store.Particles.Add(boolParticle);
                    currentContainer.AddItem(boolParticle.Id, ItemType.Particle,currentKey);
                    break;
                
                case JsonTokenType.Number:
                    int intValue = reader.GetInt32();
                    var intParticle = new Particle { Value = intValue, Type = ParticleType.Number};
                    store.Particles.Add(intParticle);
                    currentContainer.AddItem(intParticle.Id, ItemType.Particle, currentKey);
                    break;
                case JsonTokenType.Null:
                    break;
                
                //skip
                case JsonTokenType.None:
                case JsonTokenType.Comment:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        return store;
    }
}

public class JsonStore
{
    public List<Container> Containers { get; set; } = new();
    public List<Particle> Particles { get; set; } = new();
}
