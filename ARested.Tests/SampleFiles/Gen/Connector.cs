﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TEST
{

    public class Connector
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("defaultName")]
        public string DefaultName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("adapter")]
        public Adapter4 Adapter { get; set; }

        [JsonProperty("transport")]
        public Transport4 Transport { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sourceFile")]
        public object SourceFile { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }

}
