using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CVLab.Data
{
        public class Skill
        {
            [BsonId]
            public ObjectId Id { get; set; }

            public string SkellName { get; set; }

            public int YearsOfExperience { get; set; }
            public int level { get; set; }
    }
    }


