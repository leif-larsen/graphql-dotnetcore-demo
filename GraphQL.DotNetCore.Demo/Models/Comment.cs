using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.DotNetCore.Demo.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post BlogPost { get; set; }
    }
}