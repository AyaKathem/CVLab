using MongoDB.Bson;
using MongoDB.Driver;
using CVLab.Data;
using MongoDB.Bson;

namespace CVLab.Services
{
    public class MongoDBService4
    {
       
            private readonly IMongoCollection<Project> _Project;

            public MongoDBService4(string connectionString, string databaseName)
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                _Project = database.GetCollection<Project>("Project");
            }

            public async Task<Project> GetProjectByNameAsync(string titel)
            {
                var filter = Builders<Project>.Filter.Eq(nameof(Project.Id), titel);
                return await _Project.Find(filter).FirstOrDefaultAsync();
            }
            public async Task<List<Project>> GetProjectAsync()
            {
                return await _Project.Find(_ => true).ToListAsync();
            }

            public async Task AddProjectAsync(Project CvMainDate)
            {
                await _Project.InsertOneAsync(CvMainDate);
            }
            public async Task UpdateProjectAsync(ObjectId id, Project project)
            {
                var filter = Builders<Project>.Filter.Eq(nameof(project.Id), id);
                var update = Builders<Project>.Update
                    .Set(s => s.Titel, project.Titel)
                    .Set(s => s.Text, project.Text);

                await _Project.UpdateOneAsync(filter, update);
            }

            public async Task DeleteProjectAsync(ObjectId id)
            {
                var filter = Builders<Project>.Filter.Eq(nameof(Project.Id), id);
                await _Project.DeleteOneAsync(filter);
            }
        }
    }

