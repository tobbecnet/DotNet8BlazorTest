namespace BlogToolkit.Repository;

public class BlogToolkitDbSettings
{
    public string MongoDbUser { get; set; } = null!;
    public string MongoDbPassword { get; set; } = null!;
    public string ConnectionUri { get; set; } = null!;
}
