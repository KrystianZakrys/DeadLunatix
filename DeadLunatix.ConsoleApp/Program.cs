
using DeadLunatix.ConsoleApp.Configuration;
using DeadLunatix.Generator;
using System.Configuration;
using System.Text.Json;

try
{
    var cfg = new MyConfiguration();
    var generator = new Generator(cfg);

    var results = generator.Generate();
    Console.WriteLine("Done");
   
    results.RankCombinationsByRarity();

    string jsonData = JsonSerializer.Serialize(results);
    System.IO.File.WriteAllText(@$"{cfg.OutputDirectory}/jsondata.txt", jsonData);

}
catch (Exception e)
{
    Console.WriteLine("You unleashed the demons");
    Console.WriteLine(e.Message);
}

