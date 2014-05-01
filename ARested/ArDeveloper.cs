using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ArestedDevelopment.Models;

namespace ArestedDevelopment
{
    /// <summary>
    /// Main class for running a develop job
    /// </summary>
    public class ArDeveloper
    {
        private List<IInterpreter> _interpreters;

        public bool AddInterpreter(IInterpreter interpreter)
        {
            // what do we need???

            if (!interpreter.Load()) // load the interpreter
                return false;

            // check the stubs??
            //interpreter.Stubs
            
            _interpreters.Add(interpreter);

            throw new System.NotImplementedException();
        }

        public bool AddOutputProcessor(IOutputProcessor processor)
        {
            throw new System.NotImplementedException();
        }

        public bool LoadResource(IResource resource)
        {
            // find appropriate interpreters to handle the resource

            _interpreters.FirstOrDefault(interpreter => interpreter.CheckResource(resource));

            throw new System.NotImplementedException();
        }

        public object Develop()
        {
            // marry up the resources, interpreters, and output processors!

            _interpreters.ForEach(interpreter =>
            {
                //interpreter.

            });


            throw new System.NotImplementedException();
        }
    }
}
