// -----------------------------------------------------------------------
// <copyright file="UserService.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Service
{
    using System.Threading.Tasks;
    using GuardAgainstLib;
    using NewClassrooms.Entity;
    using NewClassrooms.Service.Enum;
    using NewClassrooms.Service.Interface;

    /// <summary>
    /// Provides an implementation of <see cref="IUserService"/>.
    /// </summary>
    public class UserService : IUserService
    {
        /// <inheritdoc/>
        public async Task<List<AgeRangePercentageEntity>> GetAgeRangePercentages(List<UserEntity> userEntities)
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(userEntities, nameof(userEntities));
            var results = new List<AgeRangePercentageEntity>();

            // Define age ranges
            var ageRanges = new[]
            {
            new { Min = 0, Max = 20 },
            new { Min = 21, Max = 40 },
            new { Min = 41, Max = 60 },
            new { Min = 61, Max = 80 },
            new { Min = 81, Max = 100 },
            new { Min = 100, Max = int.MaxValue },
            };

            // Calculate total user count
            int totalUsers = userEntities.Count;

            // Calculate user counts in each age range
            var ageCounts = ageRanges
                .Select(range => new
                {
                    Range = $"{range.Min}-{range.Max}",
                    Count = userEntities.Count(user => user.Age >= range.Min && user.Age <= range.Max),
                })
                .ToList();

            // Calculate percentages and return results
            foreach (var ageCount in ageCounts)
            {
                double percentage = (double)ageCount.Count / totalUsers * 100;
                results.Add(new AgeRangePercentageEntity(ageCount.Range, percentage));
            }

            return await Task.FromResult(results);
        }

        /// <inheritdoc/>
        public async Task<List<StatePopulationPercentageEntity>> GetFemalePopulationPercentages(List<UserEntity> userEntities)
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(userEntities, nameof(userEntities));

            return await this.GetPopulationByGender(userEntities, Gender.Female);
        }

        /// <inheritdoc/>
        public async Task<List<NamePercentageEntity>> GetFirstNamePercentages(List<UserEntity> userEntities)
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(userEntities, nameof(userEntities));

            char[] lettersAM = Enumerable.Range('A', 13).Select(c => (char)c).ToArray();
            int countAM = userEntities.Count(user => lettersAM.Contains(char.ToUpper(user.FirstName[0])));
            int totalCount = userEntities.Count;
            int countNZ = totalCount - countAM;

            // Calculate percentages
            double percentAM = (double)countAM / totalCount * 100;
            double percentNZ = (double)countNZ / totalCount * 100;
            return await Task.FromResult(new List<NamePercentageEntity> { new NamePercentageEntity("A-M", percentAM), new NamePercentageEntity("N-Z", percentNZ) });
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
        public async Task<List<StatePopulationPercentageEntity>> GetMalePopulationPercentages(List<UserEntity> userEntities)
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(userEntities, nameof(userEntities));

            return await this.GetPopulationByGender(userEntities, Gender.Male);
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

        private async Task<List<StatePopulationPercentageEntity>> GetPopulationByGender(List<UserEntity> userEntities, Gender gender)
        {
            var percentages = new List<StatePopulationPercentageEntity>();

            Dictionary<string, int> statePopulations = userEntities
                .GroupBy(user => user.State)
                .ToDictionary(group => group.Key, group => group.Count());

            // Calculate female populations
            Dictionary<string, int> femalePopulations = userEntities
                .Where(user => user.Gender.ToLower() == gender.ToString().ToLower())
                .GroupBy(record => record.State)
                .ToDictionary(group => group.Key, group => group.Count());

            var sortedStates = statePopulations.OrderByDescending(kv => kv.Value);

            foreach (var (state, population) in sortedStates.Take(10))
            {
                double percentage = (double)femalePopulations.GetValueOrDefault(state, 0) / population * 100;
                percentages.Add(new StatePopulationPercentageEntity(state, percentage));
            }

            return await Task.FromResult(percentages);
        }
    }
}