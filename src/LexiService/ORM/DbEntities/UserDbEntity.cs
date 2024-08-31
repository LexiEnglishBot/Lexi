namespace ORM.DbEntities;

public class UserDbEntity
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
    public int BirthDateDay { get; set; }
    public int BirthDateMonth { get; set; }
    public int BirthDateYear { get; set; }
}