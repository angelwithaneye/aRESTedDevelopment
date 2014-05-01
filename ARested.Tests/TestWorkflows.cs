using System.Collections.ObjectModel;
using ArestedDevelopment.Models;

namespace ArestedDevelopment.Tests
{
    class TestWorkflows
    {
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

            var arDev = new ArDeveloper();

            arDev.AddInterpreter(new SimpleFileInterpreter());
     
            arDev.AddOutputProcessor(new DefaultOutputProcessor());

            // load resources
            var resource = arDev.LoadResource(new UriResource() {Name = "my simple file", Type = "text/simple", Uri = ""});
            arDev.LoadResource(new UriResource() { Name = "a json file", Type = "json/simple", Uri = ""});

            arDev.LoadResource(new ManualResource() {Def = new StubDefinition() {}});

            var result = arDev.Develop();


        }
    }
}
