using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ArestedDevelopment.Models
{
    public interface IArDeveloperOutput
    {
        string Status { get; }
        string Name { get; set; }
        List<string> Outputs { get; }
    }

    public class ArDeveloperOutput : IArDeveloperOutput
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public List<string> Outputs { get; set; }
    }
}
