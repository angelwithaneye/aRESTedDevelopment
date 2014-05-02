using System.Collections.Generic;

namespace ArestedDevelopment.Models
{
    public class StubDefinition : IStubDefinition
    {
        public StubDefinition(string stubStatement)
        {
            Methods = new List<MethodDefinition>();
            StubStatement = stubStatement;
        }

        public string StubStatement { get; set; }

        public List<MethodDefinition> Methods { get; private set; }

        public void AddMethod(MethodDefinition methodDefinition)
        {
            if (Methods == null)
                Methods = new List<MethodDefinition>();

            Methods.Add(methodDefinition);
        }
    }

    public class JsonStubDefinition : IStubDefinition
    {
        public JsonStubDefinition(RootObject jsonRoot)
        {
            //StubStatement = stubStatement;
        }

        public string StubStatement { get; set; }

        public List<MethodDefinition> Methods { get; private set; }

        public void AddMethod(MethodDefinition methodDefinition)
        {
            if (Methods == null)
                Methods = new List<MethodDefinition>();

            Methods.Add(methodDefinition);
        }
    }
}
