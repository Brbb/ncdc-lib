using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace NCDCLib 
{
    public class Location
    {
		[BsonId]
        [JsonIgnore]
		public ObjectId Id { get; set; }

		//"mindate": "1891-07-01",
		[BsonElement("mindate")]
        public DateTime MinDate { get; set; }

        //"maxdate": "2017-04-26",
        [BsonElement("maxdate")]
        public DateTime MaxDate { get; set; }
      
        //"name": "Aberdeen, WA US",
        [BsonElement("name")]
        public string Name { get; set; }
      
        //"datacoverage": 1,
        [BsonElement("datacoverage")]
        public double DataCoverage { get; set; }

        //"id": "CITY:US530001"
        [BsonElement("id")]
        [JsonProperty("id")]
        public string LocationId { get; set; }
    }
}
