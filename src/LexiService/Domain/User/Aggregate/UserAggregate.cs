using Domain.User.ValueObjects;

namespace Domain.User.Aggregate;

public class UserAggregate : AggregateRoot
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? Bio { get; set; }
    public string? LanguageCode { get; set; }
    public string? ProfileImageObjectName { get; set; }
    public bool HasPrivateForwards { get; set; }
    public bool IsBot { get; set; }
    public bool IsPremium { get; set; }
    public BirthDate BirthDate { get; set; }

    public UserAggregate(long userId, string firstName, string? lastName, string? username, string? bio, string? languageCode, string? profileImageObjectName, bool hasPrivateForwards, bool isBot, bool isPremium, int birthDateDay, int birthDateMonth, int birthDateYear)
        : base(Guid.NewGuid())
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Bio = bio;
        LanguageCode = languageCode;
        ProfileImageObjectName = profileImageObjectName;
        HasPrivateForwards = hasPrivateForwards;
        IsBot = isBot;
        IsPremium = isPremium;
        BirthDate = new BirthDate(birthDateDay, birthDateMonth, birthDateYear);
    }
}