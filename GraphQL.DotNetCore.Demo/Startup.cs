using GraphQL.DotNetCore.Demo.GraphQL.Queries;
using GraphQL.DotNetCore.Demo.GraphQL.Schemas;
using GraphQL.DotNetCore.Demo.GraphQL.Types;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using GraphQL.DotNetCore.Demo.GraphQL.Mutations;

namespace GraphQL.DotNetCore.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
            services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);

            services.AddScoped<IDependencyResolver>(x =>
                new FuncDependencyResolver(x.GetRequiredService));

            services.AddScoped<PostType>();
            services.AddScoped<CommentType>();
            services.AddScoped<AuthorType>();
            services.AddScoped<BlogPostQueryGraphType>();
            services.AddScoped<PostCommentMutationGraphType>();
            services.AddScoped<Query>();
            services.AddScoped<Mutation>();
            services.AddScoped<BlogSchema>();

            services.AddGraphQL(x =>
            {
                x.ExposeExceptions = true; //set true only in development mode. make it switchable.                
            })
            .AddGraphTypes(ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            

            app.UseRouting();

            app.UseAuthorization();

            app.UseGraphQL<BlogSchema>("/graphql");
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
