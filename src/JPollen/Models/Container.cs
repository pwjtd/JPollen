namespace JPollen;

public class Container
{
    public Container()
    {
        Id = Guid.NewGuid();
        Items = new List<ContainerItem>();
    }
    public Guid Id { get; set; }
    public ContainerType Type { get; set; }
    public List<ContainerItem> Items { get; set; }

    public void AddItem(Guid itemId, ItemType itemType, string? key = null)
    {
        Items.Add(new ContainerItem
        {
            Key = key,
            Id = itemId,
            Type = itemType
        });
    }
}

public class ContainerItem
{
    public Guid Id { get; set; }
    public ItemType Type { get; set; }
    public string? Key { get; set; }
}

public enum ContainerType
{
    Object = 1, 
    Array = 2
}

public enum ItemType
{
    Container = 1,
    Particle = 2,
}