using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RestStubb.Tests
{
    [TestFixture]
    class TestBuilder
    {
        [Test]
        public void TestBuilderSimple()
        {

            Builder b = new Builder();
            b.Build("","");

        }

    }
}
