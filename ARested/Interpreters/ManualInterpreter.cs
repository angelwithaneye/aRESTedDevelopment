using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArestedDevelopment.Models;
using ArestedDevelopment.Models.Interpreters;
using ArestedDevelopment.Models.Resources;

namespace ArestedDevelopment.Interpreters
{

    public class ManualInterpreter : BaseInterpreter
    {
        public ManualInterpreter() : base("manual")
        {
        }

        public override IInterpreterResult Process()
        {
            var result =  new InterpreterResult();

            base.Resources.ForEach(resource =>
            {
                var manualResource = resource as ManualResource;

                if (manualResource == null)
                    throw new ArgumentException("resource");

                var bundle = new Bundle
                {
                    Name = manualResource.Name, 
                    RefInterpreter = this,
                    RefResource = resource, 
                    Stubs = new List<IStubDefinition>() {manualResource.Def},
                    Methods = manualResource.Def.Methods.Select(definition => definition.Name).ToList()
                };

                result.Bundles.Add(bundle);
            });

            return result;
        }
    }
}
