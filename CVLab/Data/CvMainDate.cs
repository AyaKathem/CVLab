using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CVLab.Data
{
    public class CvMainDate
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Titel { get; set; }

        public string Text { get; set; }
    }
}

