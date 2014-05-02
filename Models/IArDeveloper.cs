using System.Collections.ObjectModel;
using ArestedDevelopment.Models.Interpreters;
using ArestedDevelopment.Models.Resources;

namespace ArestedDevelopment.Models
{
    public interface IArDeveloper
    {
        ReadOnlyCollection<string> Logs { get; }

        /// <summary>
        /// main modeled output point
        /// </summary>
        ReadOnlyCollection<string> AllOutputs { get; }

        bool AddInterpreter(IInterpreter interpreter);
        bool AddOutputProcessor(IOutputProcessor processor);
        bool LoadResource(IResource resource);
        object Develop();
    }
}