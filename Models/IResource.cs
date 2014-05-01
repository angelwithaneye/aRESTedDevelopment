using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArestedDevelopment.Models
{
    public interface IResource
    {
        string Name { get; }
        string Type { get; }
    }


    public abstract class Resource : IResource
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class UriResource : Resource
    {
        public string Uri { get; set; }
    }

    public class ManualResource : Resource
    {
        public IStubDefinition Def { get; set; }
    }


}
