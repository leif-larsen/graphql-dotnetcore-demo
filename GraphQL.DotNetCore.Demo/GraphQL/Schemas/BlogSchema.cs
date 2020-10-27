using GraphQL.DotNetCore.Demo.GraphQL.Queries;
using GraphQL.Types;

namespace GraphQL.DotNetCore.Demo.GraphQL.Schemas
{
    public class BlogSchema : Schema
    {
        public BlogSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<Query>();
        }
    }
}