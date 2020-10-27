using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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