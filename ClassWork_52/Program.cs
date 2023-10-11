// See https://aka.ms/new-console-template for more information

using ClassWork_52;

Console.WriteLine("Hello, World!");
var posts = new List<Post>
{
    new Post("Hello", "World!2"),
    new Post("Hello1", "World!"),
    new Post("Hello2", "World2!"),
    new Post("Hello1", "World!"),
    new Post("Hello2", "World2!"),
    new Post("Hello", "World!"),
};


var blog = new List<BlogPost>()
{
    new BlogPost("Hello2", "World!"),
    new BlogPost("Hello1", "World!"),
    new BlogPost("Hello", "World2!"),
    new BlogPost("Hello1", "World2!"),
    new BlogPost("Hello2", "World!"),
    new BlogPost("Hello", "World2!"),
};

var result = posts.ZipExtensions(posts, post => post.Title);
foreach (var (itemA, itemB) in result)
{
    Console.WriteLine($"{itemA.Title} {itemB.Title} || {itemA.Description} {itemB.Description}");
}
