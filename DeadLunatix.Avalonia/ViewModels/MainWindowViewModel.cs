using Avalonia.Media.Imaging;
using DeadLunatix.Avalonia.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace DeadLunatix.Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";
        public string Siema => "No siemano!";
        private string InputDirectory => ConfigurationManager.AppSettings["inputDirectory"];
        private string JsonDataFileName => ConfigurationManager.AppSettings["dataJson"];
        private List<string> ElementNames => ConfigurationManager.AppSettings["elementNames"].Split(',').ToList();

        public ObservableCollection<LoadedImage> Images => new ObservableCollection<LoadedImage>(GetImages());

        public List<LoadedImage> GetImages()
        {
            var jsonDataFile = File.ReadAllText($@"{InputDirectory}{JsonDataFileName}");
            var result = new List<LoadedImage>();

            if (!string.IsNullOrEmpty(jsonDataFile))
            {
                GenerationResults generationResults = JsonSerializer.Deserialize<GenerationResults>(jsonDataFile);
                result = generationResults?.Combinations
                    .Select(x =>
                    {
                        return LoadedImageMapper.Map(x, generationResults.Combinations.IndexOf(x), InputDirectory);
                    })
                    .ToList() ?? result;

                return result;
            }

            return result;
        }

    }

    public static class LoadedImageMapper
    {
        public static LoadedImage Map(Combination combination, int rank, string InputDirectory)
        {
            var loadedImage = new LoadedImage()
            {
                Id = combination.GeneratedId,
                Description = "",
                Rank = rank + 1,
                Rarity = combination.Rarity,
                Traits = combination.ChosenAssets
            };

            Stream stream = new MemoryStream(File.ReadAllBytes($@"{InputDirectory}{combination.GeneratedId}.jpg"));

            var image = new Bitmap(stream);
            loadedImage.Image = image;
            return loadedImage;
        }
    }

    public class LoadedImage
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        public float Rarity { get; set; }
        public string Description { get; set; }
        public Dictionary<string, int> Traits { get; set; }
        public Bitmap Image { get; set; }
    }
}
