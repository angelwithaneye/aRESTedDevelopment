﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TEST
{

    public class Value
    {

        [JsonProperty("rings")]
        public IList<IList<IList<double>>> Rings { get; set; }

        [JsonProperty("spatialReference")]
        public SpatialReference SpatialReference { get; set; }
    }

}
