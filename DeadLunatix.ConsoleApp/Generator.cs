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
        public Dictionary<string, List<AssetStatistics>> GenerationStatistics;
        public List<Combination> Combinations;

        public Generator(IConfiguration cfg)
        {            
            this.cfg = cfg;
            Combinations = new List<Combination>();
            GenerationStatistics = new Dictionary<string, List<AssetStatistics>>();
            cfg.ElementNames.ForEach(x =>
            {
                List<AssetStatistics> assets = Enumerable.Range(1, GetElementsCount(x)).Select(y =>
                {
                    return new AssetStatistics(y);
                }).ToList();

                GenerationStatistics.Add(x, assets);
            });
        }

        public List<string> GetCombination(int combinationId)
        {
            Random rnd = new Random();
            var combination = new Combination(combinationId);
            
            var list = cfg.ElementNames.Select(x =>
            {
                var choosenOne = rnd.Next(1, GetElementsCount(x));
                
                CreateCombination(x, choosenOne, combination);

                return @$"{cfg.ElementsDirectory}{x}\{choosenOne}.png";
            }).ToList();

            if(Combinations.Any(x => x.ChosenAssets.All(y => combination.ChosenAssets[y.Key] == y.Value)))
            {
                return GetCombination(combinationId);
            }
            else
            {
                Combinations.Add(combination);

                return list;
            }            
        }

        private void CreateCombination(string key, int assetNumber, Combination combination)
        {
            GenerationStatistics[key].Where(x => x.AssetNumber == assetNumber).FirstOrDefault()?.AddUse();
            combination.AddAsset(key, assetNumber);
        }

        private int GetElementsCount(string elementName)
        {
            return Directory.GetFiles(cfg.ElementsDirectory+elementName, "*", SearchOption.TopDirectoryOnly).Length;
        }

        /// <summary>
        /// Generates merged png file
        /// </summary>
        /// <param name="paths">paths to asset pngs</param>
        /// <param name="resultFileName">file name without extension</param>
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

        public GenerationResults Generate()
        {
            if(!Directory.Exists(cfg.OutputDirectory))
                Directory.CreateDirectory(cfg.OutputDirectory);

            for (int i = 0; i < cfg.Amount; i++)
            {
                var generatedFilePath = @$"{cfg.OutputDirectory}\{i}.{cfg.OutputExtenstion}";
                MergeMultipleImages(GetCombination(i), generatedFilePath);
                Console.WriteLine($"Generated file: {generatedFilePath}; [{i+1}/{cfg.Amount}]");
            }
            var results = new GenerationResults(GenerationStatistics, Combinations);

            return results;
        }

        private string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

    }
}
