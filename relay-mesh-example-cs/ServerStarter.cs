using System.Threading.Tasks;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

namespace relay_mesh_example_cs
{
    public abstract class ServerStarter
    {
        public static Task StartServer(int port)
        {
            var server = new WebServer($"http://localhost:{port}/", RoutingStrategy.Regex);

            WebApiModule apiModule = new WebApiModule();
            apiModule.RegisterController<MeshController>();
            server.RegisterModule(apiModule);

            return server.RunAsync();
        }
    }
}