using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArestedDevelopment.Models.Interpreters;

namespace ArestedDevelopment.Models
{
    public interface IOutputProcessor
    {
        void Attach(List<IInterpreter> interpreters);
        void Attach(IInterpreter interpreter);
        IOutputProcessorResult GenerateOutput();
        bool Init(IArDeveloper instance);
    }
}
