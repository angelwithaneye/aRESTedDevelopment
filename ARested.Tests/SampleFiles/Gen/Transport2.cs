﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TEST
{

    public class Transport2
    {

        [JsonProperty("properties")]
        public IList<Property2> Properties { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

}
