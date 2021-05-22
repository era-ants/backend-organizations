using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Organizations.Model.Operations;

namespace Organizations.Model.Validators
{
    public sealed class CreateOrUpdateUserScoreValidator : AbstractValidator<CreateOrUpdateUserScore>
    {
        private readonly Func<Guid, CancellationToken, Task<bool>> _doesOrganizationGuidExist;
        private readonly Func<Guid, CancellationToken, Task<bool>> _doesUserGuidExist;

        public CreateOrUpdateUserScoreValidator(
            Func<Guid, CancellationToken, Task<bool>> doesOrganizationGuidExist,
            Func<Guid, CancellationToken, Task<bool>> doesUserGuidExist)
        {
            _doesOrganizationGuidExist = doesOrganizationGuidExist;
            _doesUserGuidExist = doesUserGuidExist;

            ValidateScore();
            ValidateOrganizationGuid();
            ValidateUserGuid();
        }

        private void ValidateScore()
        {
            RuleFor(x => x.Score)
                .InclusiveBetween(1, 5)
                .WithMessage("Score must be between 1 and 5");
        }

        private void ValidateOrganizationGuid()
        {
            RuleFor(x => x.OrganizationGuid)
                .MustAsync((guid, cancellationToken) => _doesOrganizationGuidExist.Invoke(guid, cancellationToken))
                .WithMessage(createUserScore =>
                    $"Organization with Guid {createUserScore.OrganizationGuid} does not exist");
        }

        private void ValidateUserGuid()
        {
            RuleFor(x => x.UserGuid)
                .MustAsync((guid, cancellationToken) => _doesUserGuidExist.Invoke(guid, cancellationToken))
                .WithMessage(createUserScore => $"User with Guid {createUserScore.UserGuid} does not exist");
        }
    }
}