using System.Text;
using System.Text.Json;

namespace JPollen;

public class JsonReleaser
{
    public string Release(JsonStore store)
    {
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        Container root = store.Containers.FirstOrDefault();
        if (root == null)
        {
            return string.Empty;
        }

        WriteContainer(writer, root, store);
        
        writer.Flush();
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    private void WriteContainer(Utf8JsonWriter writer, Container container, JsonStore store, string? propertyName = null)
    {
        if (propertyName != null)
        {
            writer.WritePropertyName(propertyName);
        }
        
        if (container.Type == ContainerType.Object)
        {
            writer.WriteStartObject();
            foreach (var item in container.Items)
            {
                if (item.Type == ItemType.Container)
                {
                    var innerContainer = store.Containers.FirstOrDefault(x => x.Id == item.Id);
                    WriteContainer(writer, innerContainer, store, item.Key);
                }
                else
                {
                    var particle = store.Particles.FirstOrDefault(x => x.Id == item.Id);
                    WriteParticle(writer, particle, item.Key);
                }
            }
            writer.WriteEndObject();
        }
        else
        {
            writer.WriteStartArray();
            foreach (var item in container.Items)
            {
                if (item.Type == ItemType.Container)
                {
                    var innerContainer = store.Containers.FirstOrDefault(x => x.Id == item.Id);
                    WriteContainer(writer, innerContainer, store, item.Key);
                }
                else
                {
                    var particle = store.Particles.FirstOrDefault(x => x.Id == item.Id);
                    WriteParticle(writer, particle, item.Key);
                }
            }
            writer.WriteEndArray();
        }
    }

    private void WriteParticle(Utf8JsonWriter writer, Particle particle, string? propertyName = null)
    {
        if (propertyName != null)
        {
            writer.WritePropertyName(propertyName);
        }

        switch (particle.Type)
        {
            case ParticleType.Number:
                writer.WriteNumberValue((int)particle.Value);
                break;
            case ParticleType.String:
                writer.WriteStringValue((string)particle.Value);
                break;
            case ParticleType.Boolean:
                writer.WriteBooleanValue((bool)particle.Value);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}