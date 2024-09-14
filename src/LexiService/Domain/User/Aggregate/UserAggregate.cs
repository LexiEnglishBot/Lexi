namespace Domain.User.Aggregate;

public class UserAggregate : AggregateRoot
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? LanguageCode { get; set; }
    public string? Step { get; set; } = string.Empty;
    public DateTime RegisterDateTime { get; set; }

    public UserAggregate(Guid id, long userId, string firstName, string? lastName, string? username, string? languageCode, string step, DateTime registerDateTime) : base(Guid.NewGuid())
    {
        Id = id;
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        LanguageCode = languageCode;
        Step = step;
        RegisterDateTime = registerDateTime;
    }

    public UserAggregate(long userId, string firstName, string? lastName, string? username, string? languageCode) : base(Guid.NewGuid())
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        LanguageCode = languageCode;
        RegisterDateTime = DateTime.UtcNow;
    }
}