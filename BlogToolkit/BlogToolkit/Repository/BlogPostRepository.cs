using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;


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


        public void PingDatabase()
        {
            // Send a ping to confirm a successful connection
            try
            {
                var result = _client.GetDatabase("tbnCluster0").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
