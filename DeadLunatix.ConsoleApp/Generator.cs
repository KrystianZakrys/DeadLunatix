using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ImageMagick;
using DeadLunatix.ConsoleApp.Models;
using DeadLunatix.ConsoleApp.Configuration;

namespace DeadLunatix.Generator
{
    public class Generator
    {
        private readonly IConfiguration cfg;
        public Dictionary<string, List<AssetStatistics>> GenerationStatistics = new Dictionary<string, List<AssetStatistics>>();
        public List<Combination> Combinations = new List<Combination>();

        public Generator(IConfiguration cfg)
        {            
            this.cfg = cfg;
            
            cfg.ElementNames.ForEach(x =>
            {
                List<AssetStatistics> assets = Enumerable.Range(1, GetElementsCount(x)).Select(y =>
                {
                    return new AssetStatistics(y);
                }).ToList();

                GenerationStatistics.Add(x, assets);
            });
        }

        /// <summary>
        /// Creates random combination of elements described in cfg. If combination exists repeat until new.
        /// </summary>
        /// <param name="combinationId">Id of combination thats going to be generated</param>
        /// <returns>List of paths of element asset files</returns>
        public List<string> GetCombinationPaths(int combinationId)
        {
            Random rnd = new Random();
            var combination = new Combination(combinationId);
            
            var list = cfg.ElementNames.Select(x =>
            {
                var choosenOne = rnd.Next(1, GetElementsCount(x));
                UpdateCombination(x, choosenOne, combination);
                return @$"{cfg.ElementsDirectory}{x}\{choosenOne}.png";
            })
            .ToList();

            if(Combinations.Any(x => x.ChosenAssets.All(y => combination.ChosenAssets[y.Key] == y.Value)))
            {
                return GetCombinationPaths(combinationId);
            }
            else
            {
                Combinations.Add(combination);

                return list;
            }            
        }

        /// <summary>
        /// Updates empty combination with adding new asset.
        /// </summary>
        /// <param name="key">Asset group name</param>
        /// <param name="assetNumber">Asset number</param>
        /// <param name="combination">Combination to be updated</param>
        private void UpdateCombination(string key, int assetNumber, Combination combination)
        {
            GenerationStatistics[key].Where(x => x.AssetNumber == assetNumber).FirstOrDefault()?.AddUse();
            combination.AddAsset(key, assetNumber);
        }

        /// <summary>
        /// Gets element asset files count.
        /// </summary>
        /// <param name="elementName">asset group name</param>
        /// <returns>count of files in asset group</returns>
        private int GetElementsCount(string elementName)
        {
            return Directory.GetFiles(cfg.ElementsDirectory+elementName, "*", SearchOption.TopDirectoryOnly).Length;
        }

        /// <summary>
        /// Generates merged jpg file
        /// </summary>
        /// <param name="paths">paths to asset pngs</param>
        /// <param name="outputPath">directory where merged files going to be saved in</param>
        private void MergeMultipleImages(List<string> paths, string outputPath)
        {
            try
            {
                using (var images = new MagickImageCollection())
                {
                    foreach (var path in paths)
                    {
                        var image = new MagickImage(@path);
                        images.Add(image);
                    }

                    // Create a mosaic from both images
                    using (var result = images.Mosaic())
                    {
                        // Save the result
                        result.WriteAsync(@outputPath);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }         
        }    

        /// <summary>
        /// Generates multiple merged combinations.
        /// </summary>
        /// <returns>Statistics of generation</returns>
        public GenerationResults Generate()
        {
            if(!Directory.Exists(cfg.OutputDirectory))
                Directory.CreateDirectory(cfg.OutputDirectory);

            for (int i = 0; i < cfg.Amount; i++)
            {
                var generatedFilePath = @$"{cfg.OutputDirectory}\{i}.{cfg.OutputExtenstion}";
                MergeMultipleImages(GetCombinationPaths(i), generatedFilePath);
                Console.WriteLine($"Generated file: {generatedFilePath}; [{i+1}/{cfg.Amount}]");
            }
            var results = new GenerationResults(GenerationStatistics, Combinations);

            return results;
        }       

    }
}
