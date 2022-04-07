using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadLunatix.Avalonia.Models
{
    public class GenerationResults
    {
        public Dictionary<string, List<AssetStatistics>> GenerationStatistics { get; set; }
        public List<Combination> Combinations { get; set; }
    }

    public class Combination
    {
        public int GeneratedId { get; set; }
        public Dictionary<string, int> ChosenAssets { get; set; } = new Dictionary<string, int>();
        public float Rarity { get; set; }
    }


    public class AssetStatistics
    {
        public int AssetNumber { get; set; }
        public float HowManyTimesUsed { get; set; }
       
    }


}
