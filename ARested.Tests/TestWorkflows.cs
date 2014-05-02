using System.Collections.ObjectModel;
using ArestedDevelopment.Interpreters;
using ArestedDevelopment.Models;
using ArestedDevelopment.Models.Resources;
using ArestedDevelopment.OutputProcessors;
using NUnit.Framework;

namespace ArestedDevelopment.Tests
{
    [TestFixture]
    class TestWorkflows
    {
        [Test]
        public void TestFull()
        {
            // start ArDeveloper
            // add files (json, txt, html, urlsniff)
            // process files
            //      build
            //      runplugins (??)
            //      output common interface
            // ArDevelopmentPlanner builds output
            // done

            //var ar2 = new ArDeveloper(developerConfig => { developerConfig.PluginLocation = "" });

            var arDev = new ArDeveloper();

            arDev.Test();

            arDev.AddInterpreter(new SimpleFileInterpreter());
            arDev.AddInterpreter(new ManualInterpreter());

            var config = new SingleFileOutputProcessorConfig() {OutputPath = @"C:\Projects\Other\ARestedDevelopment\ARested.Tests\SampleFiles\Gen\singlefileoutput\ONE.cs"};
            arDev.AddOutputProcessor(new SingleFileOutputProcessor(config));

            var config2 = new SingleFileOutputProcessorConfig() { OutputPath = @"C:\Projects\Other\ARestedDevelopment\ARested.Tests\SampleFiles\Gen\singlefileoutput\TWO.cs" };
            arDev.AddOutputProcessor(new SingleFileOutputProcessor(config2));

            // load resources
            var resource = arDev.LoadResource(new UriResource()
            {
                Name = "my simple file",
                Type = "text/simple", 
                Uri = @"C:\Projects\Other\ARestedDevelopment\ARested.Tests\SampleFiles\simple.txt"
            });

            arDev.LoadResource(new UriResource()
            {
                Name = "a json file", 
                Type = "json/simple",
                Uri = @"C:\Projects\Other\ARestedDevelopment\ARested.Tests\SampleFiles\simple.json"
            });


            var stubDef = new StubDefinition("");
            stubDef.Methods.Add(new MethodDefinition("ManualMETH", "bool", null));
            
            arDev.LoadResource(new ManualResource() { Name = "somemanualresource", Def = stubDef });

            var result = arDev.Develop();


            var l = arDev.Logs;

        }
    }
}
