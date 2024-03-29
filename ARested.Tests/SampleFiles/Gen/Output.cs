﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TEST
{

    public class Output
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("connector")]
        public string Connector { get; set; }

        [JsonProperty("connectorLabel")]
        public string ConnectorLabel { get; set; }

        [JsonProperty("adapter")]
        public Adapter3 Adapter { get; set; }

        [JsonProperty("transport")]
        public Transport3 Transport { get; set; }

        [JsonProperty("runningState")]
        public string RunningState { get; set; }

        [JsonProperty("supportsAllGeoEventDefinitions")]
        public bool SupportsAllGeoEventDefinitions { get; set; }

        [JsonProperty("supportedGeoEventDefinitions")]
        public IList<object> SupportedGeoEventDefinitions { get; set; }

        [JsonProperty("geoEventDefinitionHistory")]
        public IList<string> GeoEventDefinitionHistory { get; set; }

        [JsonProperty("statusDetails")]
        public string StatusDetails { get; set; }

        [JsonProperty("geoEventsRateRange")]
        public GeoEventsRateRange2 GeoEventsRateRange { get; set; }
    }

}
