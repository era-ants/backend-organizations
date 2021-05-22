using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Organizations.Model.Validators;

namespace Organizations.Model.Operations
{
    public sealed class CreateOrUpdateUserScore
    {
        private CreateOrUpdateUserScore(Guid organizationGuid, Guid userGuid, int score)
        {
            OrganizationGuid = organizationGuid;
            UserGuid = userGuid;
            Score = score;
        }

        public Guid OrganizationGuid { get; }
        
        public Guid UserGuid { get; }
        
        public int Score { get; }

        public static CreateOrUpdateUserScore NewAsync(
            Guid organizationGuid,
            Guid userGuid,
            int score,
            Func<Guid, CancellationToken, Task<bool>> doesOrganizationGuidExist,
            Func<Guid, CancellationToken, Task<bool>> doesClientGuidExist)
        {
            var createOrUpdateUserScore = new CreateOrUpdateUserScore(organizationGuid, userGuid, score);
            new CreateOrUpdateUserScoreValidator(doesOrganizationGuidExist, doesClientGuidExist)
                .ValidateAndThrowAsync(createOrUpdateUserScore);
            return createOrUpdateUserScore;
        }
    }
}