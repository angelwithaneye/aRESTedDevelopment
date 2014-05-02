using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using ArestedDevelopment.Models;
using ArestedDevelopment.Models.Interpreters;
using ArestedDevelopment.Models.Resources;
using ArestedDevelopment.Plugin;

namespace ArestedDevelopment
{
    /// <summary>
    /// Main class for running a develop job
    /// </summary>
    public class ArDeveloper : IArDeveloper
    {
        [ImportMany(typeof(IInterpreter))]
        private List<IInterpreter> _interpreters;

        [ImportMany(typeof(IResource))]
        private List<IResource> _resources;

        [ImportMany(typeof(IOutputProcessor))]
        private List<IOutputProcessor> _outputProcessors;
        
        private List<string> _logger;
        
        public ArDeveloper()
        {
            _logger = new List<string>();

            _interpreters = new List<IInterpreter>();
            _resources = new List<IResource>();
            _outputProcessors = new List<IOutputProcessor>();
            
            var manager = new PluginManager(@"C:\Projects\Other\ARestedDevelopment\ARested.PluginTests\bin\Debug");
            //manager.LoadFromAppDomain(this);
            //manager.LoadAll(this);

        }

        public ArDeveloper(Action<ArDeveloperConfig> configurator)
        {
            var config = new ArDeveloperConfig();

            _logger = new List<string>();

            _interpreters = new List<IInterpreter>();
            _resources = new List<IResource>();
            _outputProcessors = new List<IOutputProcessor>();

            if (configurator != null)
                configurator(config);

            // use config!

            //var manager = new PluginManager(@"C:\Projects\Other\ARestedDevelopment\ARested.PluginTests\bin\Debug");
            //manager.LoadAll(this);

        }

        public bool AddInterpreter(IInterpreter interpreter)
        {
            // what do we need???

            if (!interpreter.Init(this)) // init the interpreter
                return false;

            _interpreters.Add(interpreter);

            return true;
        }

        public bool AddOutputProcessor(IOutputProcessor processor)
        {
            if (!processor.Init(this)) // init the processor
                return false;

            _outputProcessors.Add(processor);
            return true;
        }

        public bool LoadResource(IResource resource)
        {
            if (!resource.Init(this)) // init the resource
                return false;

            _resources.Add(resource);
            return true;
        }

        public void Test()
        {
            var t = this;
        }

        public object Develop()
        {
            // build workflow
            // marry up the resources, interpreters, and output processors!

            _resources.ForEach(resource =>
            {
                  // find appropriate interpreter to handle the resource
                var found = _interpreters.FirstOrDefault(interpreter => interpreter.CheckResource(resource));

                if (found == null)
                {
                    // log no interpreter found for resource
                    _logger.Add("no interpreter found for resource " + resource.Name);
                }

            });

            // attach all interpreters to all processors
            _outputProcessors.ForEach(processor => processor.Attach(_interpreters));

            // start processing
            _outputProcessors.ForEach(processor =>
            {
                var processResult = processor.GenerateOutput();

                // do something with the result

            });

            return false;
        }

        public ReadOnlyCollection<string> Logs {
            get { return new ReadOnlyCollection<string>(_logger); }
        }

        public ReadOnlyCollection<string> AllOutputs
        {
            get { return new ReadOnlyCollection<string>(new string[0]); }
        }
    }

}
