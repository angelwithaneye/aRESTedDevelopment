using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArestedDevelopment.Models.OutputProcessor;

namespace ArestedDevelopment.OutputProcessors
{
    public class OutputProcessorResult : IOutputProcessorResult
    {
        public string Status { get; set; }
    }
}
