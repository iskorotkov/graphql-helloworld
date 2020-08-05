using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace HelloWorld
{
    public class SchemaFirst
    {
        public class Droid
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class Query
        {
            [GraphQLMetadata("hero")]
            public Droid GetHero() => new Droid { Id = "1", Name = "R2-D2" };
        }

        public async Task Run()
        {
            var schema = Schema.For(@"
                type Droid {
                    id: String!
                    name: String!
                }

                type Query {
                    hero: Droid
                }
            ", _ => _.Types.Include<Query>());

            var json = await schema.ExecuteAsync(_ => _.Query = "{ hero { id name } }").ConfigureAwait(false);

            Console.WriteLine(json);
        }
    }
}
