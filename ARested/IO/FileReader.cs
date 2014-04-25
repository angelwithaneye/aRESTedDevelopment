using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestStubb.Models;

namespace RestStubb.IO
{
    /// <summary>
    /// Read dat file
    /// </summary>
    public class FileReader
    {
        public SimpleFile LoadSimpleFile(string filename)
        {
            var simpleFile = new SimpleFile() {Stubs = new List<IStubDefinition>()};

            using (var sr = File.OpenText(filename))
            {
                var s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    simpleFile.Stubs.Add(new StubDefinition());
                }
            }

            return simpleFile;
        }
    }
}
