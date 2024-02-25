using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace CVLab.Data
{
    public class WorkExperience
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Place { get; set; }
        public string type { get; set; }
        public string Titel { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string text { get; set; }
    }
}
