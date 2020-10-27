using GraphQL.DotNetCore.Demo.Models;
using GraphQL.Types;

namespace GraphQL.DotNetCore.Demo.GraphQL.Types
{
    public class PostType : ObjectGraphType<Post>
    {
        public PostType()
        {
            Name = "BlogPost";

            Field(f => f.Id, type: typeof(IdGraphType)).Description("Blog post ID");
            Field(f => f.Title).Description("Blog post title");
            Field(f => f.Summary).Description("Blog post summary");
            Field(f => f.Body).Description("Blog post content");

            Field(f => f.Author, type: typeof(AuthorType)).Description("Blog post author");
            Field(f => f.Comments, type: typeof(ListGraphType<CommentType>)).Description("Blog post comments");
        }
    }
}