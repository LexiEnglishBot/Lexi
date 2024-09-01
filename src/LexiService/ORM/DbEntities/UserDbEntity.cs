namespace ORM.DbEntities;

public class UserDbEntity
{
    public Guid Id { get; set; }
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? LanguageCode { get; set; }
}