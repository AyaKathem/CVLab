using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CVLab.Data
{
    public class Project
    {
            [BsonId]
            public ObjectId Id { get; set; }

            public string Titel { get; set; }

            public string Text { get; set; }
        
    }
}
