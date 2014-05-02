using System;
using System.Collections.Generic;
using ArestedDevelopment.Models.Resources;

namespace ArestedDevelopment.Models.Interpreters
{
    public interface IInterpreter
    {
        List<IStubDefinition> Stubs { get; set; }

        Func<IResource, bool> CheckResource { get; }

       //IStubDefinition Stubs { get; set; }

        bool Init(IArDeveloper instance);
        IInterpreterResult Process();
    }

    public interface IInterpreterResult
    {
        // we need to figure out what we need to return...
        // what does the output processor need?

        // classes/models
        // methods
        // bundle?

        List<Bundle> Bundles { get; }
    }

    public class Bundle
    {
        public Bundle()
        {
            Stubs = new List<IStubDefinition>();
            Classes = new List<string>();
            Methods = new List<string>();
        }

        public string Name { get; set; }
        public IResource RefResource { get; set; }
        public IInterpreter RefInterpreter { get; set; }
        public List<IStubDefinition> Stubs { get; set; }
        public List<string> Classes { get; set; }
        public List<string> Methods { get; set; }
    }

}