using System.Collections.Generic;

namespace ARestedDevelopment.Models
{
    public interface IStubDefinition
    {
        string StubStatement { get; set; }
        List<MethodDefinition> Methods { get; }


        void AddMethod(MethodDefinition methodDefinition);

    }
}
