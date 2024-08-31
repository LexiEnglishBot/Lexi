using FluentResults;

namespace Domain.Bot.ValueObjects;

public class ApiKey : ValueObject
{
    public string Key { get; private set; }

    public ApiKey(string key)
    {
        Key = key;
    }

    public override Result IsValid()
    {
        if (string.IsNullOrEmpty(Key)) return Result.Fail("ApiKey can't be null or empty");
        if (Key.Length < 40) return Result.Fail("ApiKey length can't be less than 40");
        if (Key.Length > 50) return Result.Fail("ApiKey length can't be greater than 50");

        return Result.Ok();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Key;
    }
}