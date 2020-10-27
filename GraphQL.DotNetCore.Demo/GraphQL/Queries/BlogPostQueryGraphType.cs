using GraphQL.DotNetCore.Demo.GraphQL.Types;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GraphQL.DotNetCore.Demo.GraphQL.Queries
{
    public class BlogPostQueryGraphType : ObjectGraphType
    {
        public BlogPostQueryGraphType()
        {
            Field<ListGraphType<PostType>>(
                "posts",
                resolve: context =>
                {
                    using (var db = new BlogDbContext())
                    {
                        return db.BlogPosts
                            .Include(x => x.Author)
                            .Include(x => x.Comments)
                            .ToList();
                    }
                }
            );

            Field<PostType>(
                "post",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "Id", Description = "ID of blog post" }),
                resolve: context =>
                {

                    using (var db = new BlogDbContext())
                    {
                        int.TryParse(context.GetArgument<string>("id"), out int id);

                        return db.BlogPosts
                            .Include(x => x.Author)
                            .Include(x => x.Comments)
                            .SingleOrDefault(x => x.Id == id);
                    }
                }
            );
        }
    }
}