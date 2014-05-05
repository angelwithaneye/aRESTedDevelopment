using System;
using System.ComponentModel.Composition;
using ArestedDevelopment.Models.Interpreters;

namespace ARested.ExternalTests
{
    [Export(typeof(IInterpreter))]
    public class HrefInterpreter : BaseInterpreter
    {
        public HrefInterpreter() : base("href")
        {
        }

        public override IInterpreterResult Process()
        {
            throw new NotImplementedException();
        }
    }
}
