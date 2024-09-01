namespace Domain.User.Aggregate;

public class UserAggregate : AggregateRoot
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? LanguageCode { get; set; }
    public bool IsNewUser { get; set; } = true;

    public UserAggregate(Guid id, long userId, string firstName, string? lastName, string? username, string? languageCode, bool isNewUser) : base(Guid.NewGuid())
    {
        Id = id;
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        LanguageCode = languageCode;
        IsNewUser = isNewUser;
    }

    public UserAggregate(long userId, string firstName, string? lastName, string? username, string? languageCode) : base(Guid.NewGuid())
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        LanguageCode = languageCode;
    }
}