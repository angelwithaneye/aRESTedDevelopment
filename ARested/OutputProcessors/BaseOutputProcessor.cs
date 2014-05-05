using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArestedDevelopment.Models;
using ArestedDevelopment.Models.Interpreters;
using ArestedDevelopment.Models.OutputProcessor;

namespace ArestedDevelopment.OutputProcessors
{

    public abstract class BaseOutputProcessor : IOutputProcessor
    {
        protected readonly List<IInterpreter> Interpreters;

        protected BaseOutputProcessor(IOutputProcessorConfig config)
        {
            Interpreters = new List<IInterpreter>();
        }

        public virtual void Attach(List<IInterpreter> interpreters)
        {
            //_interpreters.ForEach(interpreter => interpreter.OnResultReady );

            interpreters.ForEach(interpreter =>
            {
                if (!Interpreters.Contains(interpreter)) // add only once
                    Interpreters.Add(interpreter);
            });
        }

        public virtual void Attach(IInterpreter interpreter)
        {
            if (!Interpreters.Contains(interpreter)) // add only once
                Interpreters.Add(interpreter);
        }

        public virtual IOutputProcessorResult GenerateOutput()
        {
            throw new NotImplementedException();
        }

        public virtual bool Init(IArDeveloper instance)
        {
            throw new NotImplementedException();
        }
    }
}
