using System.Collections.Generic;

namespace GraphQL.DotNetCore.Demo.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Summary { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public List<Comment> Comments { get; set; }
    }
}