﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArestedDevelopment.Models;
using ArestedDevelopment.Models.OutputProcessor;

namespace ArestedDevelopment.OutputProcessors
{
    class NancyOutputProcessor : BaseOutputProcessor
    {
        public NancyOutputProcessor(IOutputProcessorConfig config) : base(config)
        {
        }
    }
}
