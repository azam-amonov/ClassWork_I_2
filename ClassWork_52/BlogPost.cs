namespace ClassWork_52;

public class BlogPost
{
    public string Title { get; set; }
    public string Description { get; set; }

    public BlogPost(string title, string description)
    {
        Title = title;
        Description = description;
    }
}