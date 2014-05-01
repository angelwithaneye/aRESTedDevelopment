using System;
using System.Collections.Generic;

namespace ArestedDevelopment.Models
{
    public class MethodDefinition
    {
        public MethodDefinition(string name, string returnType, List<Type> paramTypes)
        {
            Name = name;
            ReturnType = returnType;

            Parameters = new List<string>();
        }

        public string HTTPMethod { get; set; }

        public string Name { get; set; }
        public string ReturnType { get; set; }
        public List<string> Parameters { get; set; }

        public override string ToString()
        {
            return string.Format("public {0} {1}(){{}}", ReturnType, Name);
        }
    }
}
