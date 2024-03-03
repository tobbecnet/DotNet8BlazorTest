using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;
using BlogToolkit.Service;


namespace BlogToolkit.Repository
{
    public class BlogPostRepository
    {
        private readonly MongoClient _client;

        public BlogPostRepository(IOptions<BlogToolkitDbSettings> dbSettings)
        {
            var settings = MongoClientSettings.FromConnectionString(dbSettings.Value.ConnectionUri);
            // Set the ServerApi field of the settings object to Stable API version 1
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            _client = new MongoClient(settings);            
        }

        public async Task<List<BlogPost>> GetAllPosts()
        {
            return await _client.GetDatabase("BlogPostDb")
                .GetCollection<BlogPost>("BlogPostCollection")
                .FindAsync<BlogPost>(Builders<BlogPost>.Filter.Empty)
                .Result
                .ToListAsync();
        }

        public async Task AddPost(BlogPost blogPost)
        {
            await _client.GetDatabase("BlogPostDb")
                .GetCollection<BlogPost>("BlogPostCollection")
                .InsertOneAsync(blogPost);
        }
    }
}
