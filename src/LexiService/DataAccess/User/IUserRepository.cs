using Domain.User.Aggregate;
using FluentResults;

namespace DataAccess.User;

public interface IUserRepository
{
    Task<Result<UserAggregate>> GetUserAsync(long userId);
    Task<Result> AddUserAsync(UserAggregate userAggregate);
    Task<Result> UpdateUserAsync(UserAggregate userAggregate);
    Task<Result<bool>> IsUserExistsAsync(long userId);
    Task<Result> SaveChangesAsync();
}