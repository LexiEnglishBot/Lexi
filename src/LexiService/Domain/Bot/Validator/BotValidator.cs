using Core.Resources.Exceptions;
using Domain.Bot.Aggregate;
using Domain.Bot.ValueObjects;
using FluentValidation;

namespace Domain.Bot.Validator;

public class BotValidator : AbstractValidator<BotAggregate>
{
    public BotValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEqual(Guid.Empty)
            .WithMessage(ExceptionMessages.INVALID_BOT_ID);

        RuleFor(x => x.Apikey).Must(ValidateApikey)
            .WithMessage(ExceptionMessages.INVALID_API_KEY);
    }

    private static bool ValidateApikey(ApiKey apiKey) => apiKey.IsValid().IsSuccess;
}