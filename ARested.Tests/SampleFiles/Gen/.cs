﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TEST
{

    public class 
    {

        [JsonProperty("adapters")]
        public IList<Adapter> Adapters { get; set; }

        [JsonProperty("transports")]
        public IList<Transport> Transports { get; set; }

        [JsonProperty("processors")]
        public IList<Processor> Processors { get; set; }

        [JsonProperty("inputs")]
        public IList<Input> Inputs { get; set; }

        [JsonProperty("outputs")]
        public IList<Output> Outputs { get; set; }

        [JsonProperty("geoEventServices")]
        public IList<GeoEventService> GeoEventServices { get; set; }

        [JsonProperty("geoEventDefinitions")]
        public IList<GeoEventDefinition2> GeoEventDefinitions { get; set; }

        [JsonProperty("tags")]
        public IList<Tag> Tags { get; set; }

        [JsonProperty("folderDataStores")]
        public IList<FolderDataStore> FolderDataStores { get; set; }

        [JsonProperty("connectors")]
        public IList<Connector> Connectors { get; set; }

        [JsonProperty("geofenceSynchronizations")]
        public IList<GeofenceSynchronization> GeofenceSynchronizations { get; set; }

        [JsonProperty("geofences")]
        public IList<Geofence> Geofences { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("arcgisServerConnections")]
        public IList<ArcgisServerConnection> ArcgisServerConnections { get; set; }
    }

}
