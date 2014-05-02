using System.Collections.Generic;
using System.ComponentModel.Composition;
using ArestedDevelopment.Models;
using ArestedDevelopment.Models.Interpreters;
using ArestedDevelopment.Models.Resources;

namespace ArestedDevelopment.Interpreters
{
    public class JsonInterpreter : IInterpreter
    {
        private string _urlToJson;

        public JsonInterpreter(string urlToJson)
        {
            _urlToJson = urlToJson;
        }

        public List<IStubDefinition> Stubs { get; set; }


        public System.Func<IResource, bool> CheckResource
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool Init(IArDeveloper instance)
        {
            return false;
        }

        public IInterpreterResult Process()
        {
            throw new System.NotImplementedException();
        }
    }
}
