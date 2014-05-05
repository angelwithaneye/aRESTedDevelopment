using System.Collections.Generic;

namespace ArestedDevelopment.Models.Jsonfile
{
    public class RootObject
    {
        public string deftype { get; set; }
        public string apptype { get; set; }
        public string appbootstrap { get; set; }
        public List<Def> defs { get; set; }
    }
}