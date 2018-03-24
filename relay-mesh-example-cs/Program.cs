using System.Threading.Tasks;
using Unosquare.Swan;

namespace relay_mesh_example_cs
{
    class Program
    {
        static readonly int port = 6374;

        static async Task Main(string[] args)
        {
            using (var serverTask = ServerStarter.StartServer(port))
            {
                $"Listening on port {port}.".Info();
                "Press Ctrl+C to exit.".Info();
                await serverTask;
            }
        }
    }
}
