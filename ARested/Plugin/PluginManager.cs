using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ArestedDevelopment.Models.Interpreters;

namespace ArestedDevelopment.Plugin
{
    internal class PluginManager
    {
        private AggregateCatalog _catalog;
        private CompositionContainer _container;
        private List<string> _pluginDirs;

        public PluginManager(List<string> pluginDirs)
        {
            _catalog = new AggregateCatalog();
            _pluginDirs = pluginDirs ?? new List<string>();
        }

        public void LoadExternal()
        {
            _pluginDirs.ForEach(dir => _catalog.Catalogs.Add(new DirectoryCatalog(dir, "*.dll")));
        }

        public void LoadFromAppDomain()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;

            var type = typeof(IInterpreter);
            var asms = AppDomain.CurrentDomain.GetAssemblies().Where((assembly => assembly.GetTypes().Any(type.IsAssignableFrom)
                                                                                  && assembly.FullName != "ArestedDevelopment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
                                                                                  && assembly.FullName != "ArestedDevelopment.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")).ToList();
            
            asms.ForEach(assembly => _catalog.Catalogs.Add(new AssemblyCatalog(assembly)));
        }

        public void ApplyTo(object instance)
        {
            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(_catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(instance);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

    }
}
