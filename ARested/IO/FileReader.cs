using System;
using System.Collections.Generic;
using System.IO;
using ArestedDevelopment.Models;

namespace ArestedDevelopment.IO
{
    /// <summary>
    /// Read dat file
    /// </summary>
    public class FileReader
    {
        public IInterpreter LoadSimpleFile(string filename)
        {
            var simpleFile = new SimpleFileInterpreter()  {Stubs = new List<IStubDefinition>()};

            using (var sr = File.OpenText(filename))
            {
                var s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    simpleFile.Stubs.Add(new StubDefinition(s));
                }
            }

            return simpleFile;
        }

        public IInterpreter LoadSimpleJson(string filename)
        {
            var jsonResource = new JsonInterpreter(null) { Stubs = new List<IStubDefinition>() };

            var fileraw = File.ReadAllText(filename);

            var jsonRoot = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(fileraw);

            jsonRoot.defs.ForEach(def =>
            {
                var rootUrl = def.root;


            });

           
            return jsonResource;
        }
    }
}
