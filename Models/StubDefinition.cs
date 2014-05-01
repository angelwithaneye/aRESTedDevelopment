using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARestedDevelopment.Models;

namespace RestStubb.Models
{
    public class StubDefinition : IStubDefinition
    {
        
        public StubDefinition(string stubStatement)
        {
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
}
