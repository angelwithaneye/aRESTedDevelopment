using NUnit.Framework;

namespace ArestedDevelopment.Tests
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
