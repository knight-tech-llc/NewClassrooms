// -----------------------------------------------------------------------
// <copyright file="UserService.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Service
{
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using GuardAgainstLib;
    using NewClassrooms.Entity;
    using NewClassrooms.Service.Interface;

    /// <summary>
    /// Provides an implementation of <see cref="IUserService"/>.
    /// </summary>
    public class UserService : IUserService
    {
        /// <inheritdoc/>
        public int GetAgeRangePercentages()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public int GetFemalePopulationPercentage()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<List<NamePercentageEntity>> GetFirstNamePercentages(List<UserEntity> userEntities)
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(userEntities, nameof(userEntities));

            // Ordinarily using Task.Run is an anti-pattern but for this exercise I think it is acceptable.
            return await Task.Run(() =>
            {
                char[] lettersAM = Enumerable.Range('A', 13).Select(c => (char)c).ToArray();
                int countAM = userEntities.Count(user => lettersAM.Contains(char.ToUpper(user.FirstName[0])));
                int totalCount = userEntities.Count;
                int countNZ = totalCount - countAM;

                // Calculate percentages
                double percentAM = (double)countAM / totalCount * 100;
                double percentNZ = (double)countNZ / totalCount * 100;
                return new List<NamePercentageEntity> { new NamePercentageEntity("A-M", percentAM), new NamePercentageEntity("N-Z", percentNZ) };
            });
        }

        /// <inheritdoc/>
        public async Task<List<NamePercentageEntity>> GetLastNamePercentages(List<UserEntity> userEntities)
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(userEntities, nameof(userEntities));

            // This method violates DRY a bit and could be refactored to make it reusable.
            char[] lettersAM = Enumerable.Range('A', 13).Select(c => (char)c).ToArray();
            int countAM = userEntities.Count(user => lettersAM.Contains(char.ToUpper(user.LastName[0])));
            int totalCount = userEntities.Count;
            int countNZ = totalCount - countAM;

            // Calculate percentages
            double percentAM = (double)countAM / totalCount * 100;
            double percentNZ = (double)countNZ / totalCount * 100;
            return await Task.FromResult(new List<NamePercentageEntity> { new NamePercentageEntity("A-M", percentAM), new NamePercentageEntity("N-Z", percentNZ) });
        }

        /// <inheritdoc/>
        public async Task<List<GenderPercentageEntity>> GetGenderPercentages(List<UserEntity> userEntities)
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(userEntities, nameof(userEntities));

            return await Task.FromResult(userEntities.GroupBy(item => item.Gender)
             .Select(group => new GenderPercentageEntity(group.Key, 100.0 * group.Count() / userEntities.Count()))
             .ToList());

        }

        /// <inheritdoc/>
        public int GetMalePopulationPercentage()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<List<StatePopulationPercentageEntity>> GetStatePopulationPercentages(List<UserEntity> userEntities)
        {
            var percentages = new List<StatePopulationPercentageEntity>();

            Dictionary<string, int> statePopulations = userEntities
                .GroupBy(user => user.State)
                .ToDictionary(group => group.Key, group => group.Count());

            long totalPopulation = statePopulations.Values.Sum();

            var sortedStates = statePopulations.OrderByDescending(kv => kv.Value);

            foreach (var (state, population) in sortedStates.Take(10))
            {
                double percentage = (double)population / totalPopulation * 100;
                percentages.Add(new StatePopulationPercentageEntity(state, percentage));
            }

            return await Task.FromResult(percentages);
        }
    }
}