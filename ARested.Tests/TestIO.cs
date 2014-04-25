using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestStubb.IO;

namespace RestStubb.Tests
{
    [TestFixture]
    public class TestIO
    {
        [Test]
        public void ReadFile()
        {
            var fileReader = new FileReader();
            
            var file = fileReader.LoadSimpleFile("");

        }

    }
}
