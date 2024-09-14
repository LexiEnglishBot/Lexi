using DataAccess.User.Mappers;
using Domain.User.Aggregate;
using FluentResults;
using ORM.DbContexts;

namespace DataAccess.User;

public class UserRepository(LexiDbContext context) : IUserRepository
{
    public async Task<Result<UserAggregate>> GetUserAsync(long userId)
    {
        try
        {
            return context.Users.First(x => x.UserId == userId).ToAggregate();
        }
        catch (Exception exception)
        {
            return Result.Fail(exception.Message);
        }
    }

    public bool TryGetUserAggregate(long userId, out UserAggregate userAggregate)
    {
        var user = context.Users.FirstOrDefault(x => x.UserId == userId);
        if (user == null)
        {
            userAggregate = null;
            return false;
        }

        userAggregate = user.ToAggregate();
        return true;
    }

    public async Task<Result> AddUserAsync(UserAggregate userAggregate)
    {
        try
        {
            await context.Users.AddAsync(userAggregate.ToDbEntity());
            return Result.Ok();
        }
        catch (Exception exception)
        {
            return Result.Fail(exception.Message);
        }
    }

    public async Task<Result> UpdateUserAsync(UserAggregate userAggregate)
    {
        try
        {
            context.Users.Update(userAggregate.ToDbEntity());
            return Result.Ok();
        }
        catch (Exception exception)
        {
            return Result.Fail(exception.Message);
        }
    }

    public async Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await context.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
        catch (Exception exception)
        {
            return Result.Fail(exception.Message);
        }
    }

    public async Task<Result<bool>> IsUserExistsAsync(long userId)
    {
        try
        {
            return context.Users.Any(x => x.UserId == userId);
        }
        catch (Exception exception)
        {
            return Result.Fail(exception.Message);
        }
    }
}