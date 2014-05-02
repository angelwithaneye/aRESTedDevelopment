using System;
using System.Collections.Generic;
using ArestedDevelopment.Models.Resources;

namespace ArestedDevelopment.Models.Interpreters
{
    public abstract class BaseInterpreter : IInterpreter
    {
        protected readonly List<IResource> Resources;
        private readonly string _resourceType;

        protected BaseInterpreter(string resourceType)
        {
            _resourceType = resourceType;
            Resources = new List<IResource>();
            Stubs = new List<IStubDefinition>();
        }

        public List<IStubDefinition> Stubs { get; set; }

        public abstract IInterpreterResult Process();

        public virtual Func<IResource, bool> CheckResource
        {
            get
            {
                return resource =>
                {
                    if (resource.Type == _resourceType)
                    {
                        if (!Resources.Contains(resource)) // add only once
                            Resources.Add(resource);

                        return true;
                    }
                    return false;

                };
            }
        }

        public virtual bool Init(IArDeveloper instance)
        {
            return true;
        }
       
    }
}