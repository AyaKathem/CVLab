using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using CVLab.Data;
using MongoDB.Bson;

namespace CVLab.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Skill> _skillCollection;

        public MongoDBService(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _skillCollection = database.GetCollection<Skill>("Skill");
        }

        public async Task<List<Skill>> GetSkillsAsync()
        {
            return await _skillCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Skill> GetSkillByNameAsync(string skillName)
        {
            var filter = Builders<Skill>.Filter.Eq(nameof(Skill.SkellName), skillName);
            return await _skillCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddSkillAsync(Skill skill)
        {
            await _skillCollection.InsertOneAsync(skill);
        }

        public async Task UpdateSkillAsync(ObjectId id, Skill skill)
        {
            var filter = Builders<Skill>.Filter.Eq(nameof(Skill.Id), id);
            var update = Builders<Skill>.Update
                .Set(s => s.SkellName, skill.SkellName)
                .Set(s => s.YearsOfExperience, skill.YearsOfExperience)
                .Set(s => s.level, skill.level);
            await _skillCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteSkillAsync(ObjectId id)
        {
            var filter = Builders<Skill>.Filter.Eq(nameof(Skill.Id), id);
            await _skillCollection.DeleteOneAsync(filter);
        }
    }
}
