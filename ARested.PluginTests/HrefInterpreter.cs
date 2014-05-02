using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArestedDevelopment.Models;
using ArestedDevelopment.Models.Interpreters;

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
