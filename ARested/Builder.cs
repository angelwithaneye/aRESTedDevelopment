using System.Collections.Generic;
using System.IO;
using System.Text;
using ArestedDevelopment.JsonCSharpClassGeneratorLib;
using ArestedDevelopment.JsonCSharpClassGeneratorLib.CodeWriters;
using ArestedDevelopment.Models;

namespace ArestedDevelopment
{
    public class Builder
    {
        public List<IStubDefinition> Stubs;

        public string Build(string json, string rootClass)
        {
            var gen = new JsonClassGenerator();

            gen.Example = json;//"{\"someprop\":\"HELLO\"}";
            gen.InternalVisibility = false;
            gen.CodeWriter = new CSharpCodeWriter();
            //gen.ExplicitDeserialization =  && gen.CodeWriter is CSharpCodeWriter;
            gen.Namespace = "TEST";
            gen.NoHelperClass = false;
            //gen.SecondaryNamespace = radDifferentNamespace.Checked && !string.IsNullOrEmpty(edtSecondaryNamespace.Text) ? edtSecondaryNamespace.Text : null;
            //gen.TargetFolder = edtTargetFolder.Text;
            gen.UseProperties = true; //radProperties.Checked;
            gen.MainClass = rootClass; //"DefaultClass";//edtMainClass.Text;
            gen.UsePascalCase = true;
            gen.UseNestedClasses = false;
            gen.ApplyObfuscationAttributes = false;
            gen.SingleFile = false;
            gen.TargetFolder = @"C:\Projects\Other\ARestedDevelopment\ARested.Tests\SampleFiles\Gen";
            gen.ExamplesInDocumentation = false;

            var stream = new MemoryStream();
            gen.OutputStream = new StreamWriter(stream, Encoding.UTF8);

            gen.GenerateClasses();
            gen.OutputStream.Flush();

            stream.Position = 0;
            TextReader reader = new StreamReader(stream);

            var text = reader.ReadToEnd();
            return text;
        }

    }
}
