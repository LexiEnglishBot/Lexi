using FluentResults;

namespace Domain.User.ValueObjects;

public class BirthDate : ValueObject
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public BirthDate(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public override Result IsValid()
    {
        if (Day is > 31 or <= 0) return Result.Fail("Invalid birthdate day provided!");
        if (Month is > 12 or <= 0) return Result.Fail("Invalid birthdate month provided!");
        if (Year is <= 0) return Result.Fail("Invalid birthdate year provided!");

        return Result.Ok();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Day;
        yield return Month;
        yield return Year;
    }
}