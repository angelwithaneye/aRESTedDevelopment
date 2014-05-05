using System.Collections.Generic;

namespace ArestedDevelopment.Models
{
    public interface IStubDefinition
    {
        string StubStatement { get; set; }
        List<MethodDefinition> Methods { get; }
        void AddMethod(MethodDefinition methodDefinition);
    }
}
