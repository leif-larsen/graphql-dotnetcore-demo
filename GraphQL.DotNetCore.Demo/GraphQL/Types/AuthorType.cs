using GraphQL.DotNetCore.Demo.Models;
using GraphQL.Types;

namespace GraphQL.DotNetCore.Demo.GraphQL.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Name = "Author";

            Field(f => f.Id, type: typeof(IdGraphType)).Description("Author ID");
            Field(f => f.Name).Description("Author name");
            Field(f => f.Bio).Description("Author bio");
        }
    }
}