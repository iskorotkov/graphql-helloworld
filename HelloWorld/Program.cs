using System.Threading.Tasks;

namespace HelloWorld
{
    internal static class Program
    {
        private static async Task Main()
        {
            await new SchemaFirstNestedTypes().Run().ConfigureAwait(false);
        }
    }
}
