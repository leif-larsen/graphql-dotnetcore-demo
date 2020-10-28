using GraphQL.Types;

namespace GraphQL.DotNetCore.Demo.GraphQL.Mutations
{
    public class Mutation : ObjectGraphType
    {
        public Mutation()
        {
            Name = "Mutation";

            Field<PostCommentMutationGraphType>("comments", resolve: context => new { });
        }
    }
}