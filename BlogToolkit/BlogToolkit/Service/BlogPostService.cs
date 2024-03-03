using BlogToolkit.Repository;

namespace BlogToolkit.Service;


public class BlogPostService(BlogPostRepository repository)
{
    private readonly BlogPostRepository _repository = repository;


    public async Task AddPost(BlogPost blogPost)
    {
        await _repository.AddPost(blogPost);

    }

    public async Task<List<BlogPost>> GetAllPosts()
    {
        return await _repository.GetAllPosts();
    }
}

public record BlogPost(
    Guid Id,
    string Title,
    string Content,
    string ImageUrl,
    string Author,
    string Introduction,
    DateTimeOffset Date
);


