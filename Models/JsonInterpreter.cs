using System.Collections.Generic;

namespace ArestedDevelopment.Models
{
    public class JsonInterpreter : IInterpreter
    {
        private string _urlToJson;

        public JsonInterpreter(string urlToJson)
        {
            _urlToJson = urlToJson;
        }

        public List<IStubDefinition> Stubs { get; set; }
    }
}
