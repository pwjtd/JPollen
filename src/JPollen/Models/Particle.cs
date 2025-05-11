namespace JPollen;

public class Particle
{
    public Particle()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public Object Value { get; set; }
    public ParticleType Type { get; set; }
}

public enum ParticleType
{
    Number = 1,
    String = 2,
    Boolean = 3,
}