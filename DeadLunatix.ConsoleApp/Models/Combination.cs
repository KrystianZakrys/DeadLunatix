using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadLunatix.ConsoleApp.Models
{
    public class Combination
    {
        public int GeneratedId { get; set; }
        public Dictionary<string, int> ChosenAssets { get; set; } = new Dictionary<string, int>();
        public float Rarity { get; set; }

        public Combination(int id)
        {
            GeneratedId = id;
        }

        public void AddAsset(string key, int assetNumber)
        {
            ChosenAssets.Add(key, assetNumber);
        }
    }       
}
