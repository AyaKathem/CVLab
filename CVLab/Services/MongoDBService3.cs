using CVLab.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CVLab.Services
{
    public class MongoDBService3
    {
        private readonly IMongoCollection<WorkExperience> _WorkCollection;

        public MongoDBService3(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _WorkCollection = database.GetCollection<WorkExperience>("WorkExperience");
        }

        public async Task<List<WorkExperience>> GetWorkAsync()
        {
            return await _WorkCollection.Find(_ => true).ToListAsync();
        }

        public async Task<WorkExperience> GetWorkByIdAsync(string workId)
        {
            var objectId = ObjectId.Parse(workId); // Parse the string workId to ObjectId
            var filter = Builders<WorkExperience>.Filter.Eq("_id", objectId); // Use "_id" field for ObjectId
            return await _WorkCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddSWorkAsync(WorkExperience NewWork)
        {
            await _WorkCollection.InsertOneAsync(NewWork);
        }

        public async Task UpdateWorkAsync(ObjectId Id, WorkExperience workData)
        {
            var filter = Builders<WorkExperience>.Filter.Eq(nameof(WorkExperience.Id), Id);
            var update = Builders<WorkExperience>.Update
                .Set(s => s.Place, workData.Place)
                .Set(s => s.type, workData.type)
                .Set(s => s.Titel, workData.Titel)
                .Set(s => s.startDate, workData.startDate)
                .Set(s => s.endDate, workData.endDate)
                .Set(s => s.text, workData.text);
            

            await _WorkCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteWorkAsync(ObjectId id)
        {
            var filter = Builders<WorkExperience>.Filter.Eq(nameof(WorkExperience.Id), id);
            await _WorkCollection.DeleteOneAsync(filter);
        }
    }
}
