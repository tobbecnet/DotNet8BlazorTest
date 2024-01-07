namespace BlogToolkit.Service
{

    public class BlogPostService
    {

        public List<BlogPost> GetPosts()
        {
            return new List<BlogPost>()
            {
                new BlogPost(Guid.NewGuid(), "Post 1", "Content for post 1", "https://example.com/post1.png", "John Doe", "Intro for post 1", DateTimeOffset.Now),
                new BlogPost(Guid.NewGuid(), "Post 2", "Content for post 2","https://example.com/post2.png", "Jane Doe", "Intro for post 2", DateTimeOffset.Now.AddDays(-1))
            };
        }
    }

    public record BlogPost(
        Guid id,
        string Title,
        string Content,
        string ImageUrl,
        string Author,
        string Introduction,
        DateTimeOffset Date
    );

}


