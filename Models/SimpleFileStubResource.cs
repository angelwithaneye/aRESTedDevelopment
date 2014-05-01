using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARestedDevelopment.Models;

namespace RestStubb.Models
{
    public interface IStubResource
    {
        List<IStubDefinition> Stubs { get; set; }
    }

    public class SimpleFileStubResource : IStubResource
    {
        public List<IStubDefinition> Stubs { get; set; }
    }
}
