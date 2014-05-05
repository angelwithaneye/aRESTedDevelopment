using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using ArestedDevelopment.Models;
using ArestedDevelopment.Models.Interpreters;
using ArestedDevelopment.Models.OutputProcessor;
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
        
        /// <summary>
        /// default ctor.  Starts up with some basic defaults;  no plugins;  etc...
        /// </summary>
        public ArDeveloper() : this(config => { config.EnablePlugins = false; })
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configurator"></param>
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
            if (config.EnablePlugins)
            {
                var manager = new PluginManager(config.PluginPaths);

                manager.LoadExternal();
                manager.LoadFromAppDomain();
                manager.ApplyTo(this);
            }
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

        public IArDeveloperOutput Develop()
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

            //waht are we returning???
            return new ArDeveloperOutput(){}
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
