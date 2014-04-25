using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestStubb.Models;
using Xamasoft.JsonClassGenerator;
using Xamasoft.JsonClassGenerator.CodeWriters;

namespace RestStubb
{
    public class Builder
    {
        public List<IStubDefinition> Stubs;

        public void Build()
        {
            Xamasoft.JsonClassGenerator.JsonClassGenerator generator = new JsonClassGenerator();

            generator.CodeWriter = new CSharpCodeWriter();
            //generator.
            generator.GenerateClasses();

        }

    }
}
