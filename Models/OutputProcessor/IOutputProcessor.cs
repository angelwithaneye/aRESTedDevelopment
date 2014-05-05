using System.Collections.Generic;
using ArestedDevelopment.Models.Interpreters;

namespace ArestedDevelopment.Models.OutputProcessor
{
    public interface IOutputProcessor
    {
        void Attach(List<IInterpreter> interpreters);
        void Attach(IInterpreter interpreter);
        IOutputProcessorResult GenerateOutput();
        bool Init(IArDeveloper instance);
    }
}
