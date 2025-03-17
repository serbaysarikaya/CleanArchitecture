using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CleanArchitecture.Application.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
           where TRequest : class, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
         if(!_validators.Any())
            {
                return await next();
            }

         var context =new ValidationContext<TRequest>(request);


            var errorDictionary = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .GroupBy(
                s=> s.PropertyName,
                s => s.ErrorMessage, (propertyName,errorMesssage) => new {
                Key= propertyName,
                Values = errorMesssage.Distinct().ToArray()
                })
                .ToDictionary(s => s.Key, s => s.Values[0]);

            if(errorDictionary.Any())
            {
                var errors = errorDictionary.Select(s => new ValidationFailure
                {
                    PropertyName = s.Value,
                    ErrorCode = s.Key
                });
             throw new ValidationException(errors);
            }

            return await next();
        }
    }
}
