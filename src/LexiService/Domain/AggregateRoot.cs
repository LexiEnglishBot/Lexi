namespace Domain;

public abstract class AggregateRoot<T>
{
    public T Id { get; set; }
}

public class AggregateRoot : AggregateRoot<Guid>
{
}