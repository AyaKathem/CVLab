using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using CVLab.Data;
using MongoDB.Bson;

namespace CVLab.Services
{
    public class MongoDBService2
    {
        private readonly IMongoCollection<CvMainDate> _CvMainDate;

        public MongoDBService2(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _CvMainDate = database.GetCollection<CvMainDate>("CvMainDate");
        }

        public async Task<CvMainDate> GetProfilByNameAsync(string titel)
        {
            var filter = Builders<CvMainDate>.Filter.Eq(nameof(CvMainDate.Titel), titel);
            return await _CvMainDate.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<List<CvMainDate>> GetProfilAsync()
        {
            return await _CvMainDate.Find(_ => true).ToListAsync();
        }

        public async Task AddProfiilAsync(CvMainDate CvMainDate)
        {
            await _CvMainDate.InsertOneAsync(CvMainDate);
        }
        public async Task UpdateProfilAsync(ObjectId id, CvMainDate CvMainDate)
        {
            var filter = Builders<CvMainDate>.Filter.Eq(nameof(CvMainDate.Id), id);
            var update = Builders<CvMainDate>.Update
                .Set(s => s.Titel, CvMainDate.Titel)
                .Set(s => s.Text, CvMainDate.Text);

            await _CvMainDate.UpdateOneAsync(filter, update);
        }

        public async Task DeleteProfilAsync(ObjectId id)
        {
            var filter = Builders<CvMainDate>.Filter.Eq(nameof(CvMainDate.Id), id);
            await _CvMainDate.DeleteOneAsync(filter);
        }
    }
}