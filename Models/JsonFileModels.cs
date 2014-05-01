using System.Collections.Generic;

namespace ArestedDevelopment.Models
{
    public class Endpoint
    {
        public List<string> methods { get; set; }
        public string endpoint { get; set; }
    }

    public class Def
    {
        public string root { get; set; }
        public List<Endpoint> endpoints { get; set; }
    }

    public class RootObject
    {
        public string deftype { get; set; }
        public string apptype { get; set; }
        public string appbootstrap { get; set; }
        public List<Def> defs { get; set; }
    }
}
