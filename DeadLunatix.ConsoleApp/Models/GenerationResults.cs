using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadLunatix.ConsoleApp.Models
{
    public class GenerationResults
    {
        public Dictionary<string, List<AssetStatistics>> GenerationStatistics { get; set; }
        public List<Combination> Combinations { get; set; }

        public GenerationResults(Dictionary<string, List<AssetStatistics>> stats, List<Combination> combinations)
        {
            GenerationStatistics = stats;
            Combinations = combinations;
        }

        public List<Combination> RankCombinationsByRarity()
        {
            foreach (var combination in Combinations)
            {
                var countOfAssets = combination.ChosenAssets.Count;
                float raritySum = 0;
                foreach (var item in combination.ChosenAssets)
                {
                    var assetRarity = GenerationStatistics[item.Key]
                        .Where(x => x.AssetNumber == item.Value)
                        .FirstOrDefault()?
                        .GetGeneratedRarity(Combinations.Count) ?? 0;

                    raritySum += assetRarity;
                }

                combination.Rarity = raritySum / countOfAssets;
            }

            return Combinations = Combinations.OrderBy(x => x.Rarity).ToList();
        }

    }
}
