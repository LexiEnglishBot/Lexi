namespace Domain.User.Models;

public class BirthDateDto
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public BirthDateDto(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }
}