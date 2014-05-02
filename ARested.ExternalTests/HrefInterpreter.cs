using ArestedDevelopment.Models.Interpreters;
using System;
using System.ComponentModel.Composition;

namespace ARested.PluginTests
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
