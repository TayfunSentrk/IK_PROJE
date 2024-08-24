using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Behaviours;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        => this.validators = validators ?? throw new ArgumentNullException(nameof(validators));


    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationbResult = await Task.WhenAll(validators.Select(s => s.ValidateAsync(context, cancellationToken)));
            var failures = validationbResult.SelectMany(r => r.Errors).Where(w => w != null).ToList();

            if (failures.Any())
                throw new Exceptions.ValidationException(failures);

        }
        return await next();
    }
}
