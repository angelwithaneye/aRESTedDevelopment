﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TEST
{

    public class Condition
    {

        [JsonProperty("logicalCondition")]
        public LogicalCondition LogicalCondition { get; set; }

        [JsonProperty("spatialCondition")]
        public SpatialCondition2 SpatialCondition { get; set; }
    }

}
