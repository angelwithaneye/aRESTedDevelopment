using System;
using System.Collections.Generic;
using System.IO;
using ArestedDevelopment.Models;
using ArestedDevelopment.Models.OutputProcessor;

namespace ArestedDevelopment.OutputProcessors
{
    public class SingleFileOutputProcessorConfig : IOutputProcessorConfig
    {
        public string OutputPath { get; set; }
    }

    public class SingleFileOutputProcessor : BaseOutputProcessor
    {
        private string _outputPath;

        public SingleFileOutputProcessor(IOutputProcessorConfig config):base(config)
        {
            var cfg = config as SingleFileOutputProcessorConfig;

            if (cfg == null)
                throw new ArgumentException("Config is bad", "config");

            _outputPath = cfg.OutputPath;
        }

        public override IOutputProcessorResult GenerateOutput()
        {
            // this processor outputs a single file of all classes and other info
            var fileStream = new FileStream(_outputPath, FileMode.Create);
            var tw = new StreamWriter(fileStream);

            Interpreters.ForEach(interpreter =>
            {
                var processResult = interpreter.Process();

                //processResult.
                processResult.Bundles.ForEach(bundle =>
                {
                    tw.WriteLine(bundle.Name);
                    tw.WriteLine("Methods: " + string.Join(";", bundle.Methods));
                });

            });

            tw.Flush();
            tw.Close();
            fileStream.Close();

            // what do we need to return from here???
            return new OutputProcessorResult(){Status = "ok", }
        }

        public override bool Init(IArDeveloper instance)
        {
            return true;
        }
    }
}