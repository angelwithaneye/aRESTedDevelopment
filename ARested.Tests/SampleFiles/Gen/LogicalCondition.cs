﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TEST
{

    public class LogicalCondition
    {

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("conditions")]
        public IList<Condition2> Conditions { get; set; }
    }

}
