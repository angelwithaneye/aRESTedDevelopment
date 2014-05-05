using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace ARested.ExternalTests
{
    public class Program
    {

        public static void Main(params string [] args)
        {
            var ar = new ArestedDevelopment.ArDeveloper(config =>
            {
                config.EnablePlugins = true;
            });

            var result = ar.Develop();
  
        }
    }
}
