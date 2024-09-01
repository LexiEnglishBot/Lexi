using Domain.User.Aggregate;
using ORM.DbEntities;

namespace DataAccess.User.Mappers;

public static class UserMapper
{
    public static UserAggregate ToAggregate(this UserDbEntity entity)
    {
        return new UserAggregate(
            entity.Id,
            entity.UserId,
            entity.FirstName,
            entity.LastName,
            entity.Username,
            entity.LanguageCode,
            false
            );
    }

    public static UserDbEntity ToDbEntity(this UserAggregate userAggregate)
    {
        return new UserDbEntity()
        {
            Id = userAggregate.Id,
            UserId = userAggregate.UserId,
            FirstName = userAggregate.FirstName,
            LastName = userAggregate.LastName,
            Username = userAggregate.Username,
            LanguageCode = userAggregate.LanguageCode,
        };
    }
}