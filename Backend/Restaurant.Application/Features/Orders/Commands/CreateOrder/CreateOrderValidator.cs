using FluentValidation;

namespace Restaurant.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderValidator
    : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.TableNumber)
            .GreaterThan(0)
            .WithMessage("Table number must be greater than zero");
    }
}
