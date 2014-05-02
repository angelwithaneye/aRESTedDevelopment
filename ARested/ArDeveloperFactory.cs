using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArestedDevelopment.Interpreters;
using ArestedDevelopment.Models;
using ArestedDevelopment.Models.Resources;
using ArestedDevelopment.OutputProcessors;

namespace ArestedDevelopment
{
    public static class ArDeveloperFactory
    {
        public static IArDeveloper SingleFileInOut(string file, string outputFile)
        {
            var arDev = new ArDeveloper();

            arDev.AddInterpreter(new SimpleFileInterpreter());

            var config = new SingleFileOutputProcessorConfig() { OutputPath = outputFile };
            arDev.AddOutputProcessor(new SingleFileOutputProcessor(config));

            arDev.LoadResource(new UriResource()
            {
                Name = "my simple file",
                Type = "text/simple",
                Uri = file
            });

            return arDev;
        }
    }
}
