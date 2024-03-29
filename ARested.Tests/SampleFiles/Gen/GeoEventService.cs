﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TEST
{

    public class GeoEventService
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("runningState")]
        public string RunningState { get; set; }

        [JsonProperty("inputs")]
        public IList<Input2> Inputs { get; set; }

        [JsonProperty("outputs")]
        public IList<Output2> Outputs { get; set; }

        [JsonProperty("nodes")]
        public IList<Node> Nodes { get; set; }

        [JsonProperty("flow")]
        public IList<Flow> Flow { get; set; }

        [JsonProperty("geoEventsReceivedRateRange")]
        public GeoEventsReceivedRateRange GeoEventsReceivedRateRange { get; set; }

        [JsonProperty("geoEventsSentRateRange")]
        public GeoEventsSentRateRange GeoEventsSentRateRange { get; set; }
    }

}
