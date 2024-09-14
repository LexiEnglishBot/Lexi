namespace Domain;

public abstract class AggregateRoot<T>
{
    public T Id { get; set; }

    protected AggregateRoot(T id)
    {
        Id = id;
    }
}

public class AggregateRoot : AggregateRoot<Guid>
{
    public AggregateRoot(Guid id) : base(id)
    {
    }
}