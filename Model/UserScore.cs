using System;
using Organizations.Model.Operations;

namespace Organizations.Model
{
    public sealed class UserScore
    {
        private UserScore(Guid organizationGuid, Guid userGuid, int score)
        {
            OrganizationGuid = organizationGuid;
            UserGuid = userGuid;
            Score = score;
        }

        public Guid OrganizationGuid { get; }

        public Guid UserGuid { get; }

        public int Score { get; private set; }

        public static UserScore New(CreateOrUpdateUserScore createOrUpdateUserScore)
        {
            return new(
                createOrUpdateUserScore.OrganizationGuid,
                createOrUpdateUserScore.UserGuid,
                createOrUpdateUserScore.Score);
        }

        public void Update(CreateOrUpdateUserScore createOrUpdateUserScore)
        {
            if (OrganizationGuid != createOrUpdateUserScore.OrganizationGuid
                || UserGuid != createOrUpdateUserScore.UserGuid)
                throw new ArgumentException("Wrong Guids for user score", nameof(createOrUpdateUserScore));
            Score = createOrUpdateUserScore.Score;
        }
    }
}