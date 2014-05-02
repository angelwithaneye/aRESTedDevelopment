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
        private CompositionContainer _container;
        private string _pluginDir;

        public PluginManager(string pluginDir)
        {
            _pluginDir = pluginDir;
        }


        public void LoadAll(object loadInto)
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new DirectoryCatalog(_pluginDir, "*.dll"));

            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(loadInto);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }


        public void LoadFromAppDomain(object loadInto)
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            //Adds all the parts found in the same assembly as the Program class

            var path = AppDomain.CurrentDomain.BaseDirectory;

            var type = typeof(IInterpreter);
            var asms = AppDomain.CurrentDomain.GetAssemblies().Where((assembly => assembly.GetTypes().Any(type.IsAssignableFrom)
                                                                                  && assembly.FullName != "ArestedDevelopment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
                                                                                  && assembly.FullName != "ArestedDevelopment.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")).ToList();

            asms.ForEach(assembly =>
            {
                catalog.Catalogs.Add(new AssemblyCatalog(assembly));
            });
          

            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(loadInto);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

    }
}
