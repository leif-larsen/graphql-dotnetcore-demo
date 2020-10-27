using GraphQL.DotNetCore.Demo.Models;
using GraphQL.Types;

namespace GraphQL.DotNetCore.Demo.GraphQL.Types
{
    public class CommentType : ObjectGraphType<Comment>
    {
        public CommentType()
        {
            Name = "Comment";

            Field(f => f.Id, type: typeof(IdGraphType)).Description("Comment ID");
            Field(f => f.Name).Description("Comment author name");
            Field(f => f.Email).Description("Comment author email");
            Field(f => f.Text).Description("Comment content");

            //Field(f => f.Post, type: typeof(PostType)).Description("Associated blog post");
        }
    }
}