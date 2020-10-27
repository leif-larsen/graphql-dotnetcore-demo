using GraphQL.Types;

namespace GraphQL.DotNetCore.Demo.GraphQL.Types
{
    public class CommentInputType : InputObjectGraphType
    {
        public CommentInputType()
        {
            Name = "CommentInput";

            Field<NonNullGraphType<StringGraphType>>("text");
            Field<StringGraphType>("email");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<IntGraphType>>("postid");
        }
    }
}