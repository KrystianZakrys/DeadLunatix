using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadLunatix.ConsoleApp.Models
{
    public class AssetStatistics
    {
        public int AssetNumber { get; set; }
        public float HowManyTimesUsed { get; set; }

        public AssetStatistics(int assetNumber)
        {
            AssetNumber = assetNumber;
        }

        public void AddUse()
        {
            HowManyTimesUsed += 1;
        }

        public float GetGeneratedRarity(int allCombinations) => (HowManyTimesUsed / allCombinations) * 100;        
    }
}
