using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArestedDevelopment
{
    public class ArDeveloperConfig
    {
        public ArDeveloperConfig()
        {
            PluginPaths = new List<string>();
            EnablePlugins = false;
        }

        public bool EnablePlugins { get; set; }
        public List<string> PluginPaths { get; set; }
    }
}
