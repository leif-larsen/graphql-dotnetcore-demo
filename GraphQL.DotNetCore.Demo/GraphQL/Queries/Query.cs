using GraphQL.Types;

namespace GraphQL.DotNetCore.Demo.GraphQL.Queries
{
    public class Query : ObjectGraphType
    {
        public Query()
        {
            Name = "Query";

            Field<BlogPostQueryGraphType>("blogposts", resolve: context => new { });
        }
    }
}