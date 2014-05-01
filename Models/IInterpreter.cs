using System;
using System.Collections.Generic;

namespace ArestedDevelopment.Models
{
    public interface IInterpreter
    {
        List<IStubDefinition> Stubs { get; set; }

        Func<IResource, bool> CheckResource { get; }

        bool Load();
    }
}