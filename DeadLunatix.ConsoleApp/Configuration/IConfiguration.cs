using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadLunatix.ConsoleApp.Configuration
{
    public interface IConfiguration
    {
        string OutputDirectory { get; }
        string OutputExtenstion { get; }
        int Amount { get; }
        List<string> ElementNames { get; }
        string ElementsDirectory { get; }
    }
}
