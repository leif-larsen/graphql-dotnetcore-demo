using GraphQL.DotNetCore.Demo.GraphQL.Types;
using GraphQL.DotNetCore.Demo.Models;
using GraphQL.Types;

namespace GraphQL.DotNetCore.Demo.GraphQL.Mutations
{
    public class PostCommentMutationGraphType : ObjectGraphType
    {
        public PostCommentMutationGraphType()
        {
            Field<CommentType>(
                "addComment",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CommentInputType>> { Name = "comment" }),
                resolve: context =>
                {
                    var comment = context.GetArgument<Comment>("comment");

                    using (var db = new BlogDbContext())
                    {
                        var entity = db.Comments.Add(comment);
                        db.SaveChanges();

                        return entity.Entity;
                    };
                }
            );
        }
    }
}