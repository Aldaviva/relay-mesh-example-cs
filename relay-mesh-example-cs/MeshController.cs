using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;
using Unosquare.Swan;

namespace relay_mesh_example_cs
{
    public class MeshController : WebApiController
    {
        [WebApiHandler(HttpVerbs.Get, "/{ipAddress}/capabilities")]
        public bool Capabilities(WebServer server, HttpListenerContext context, string ipAddress)
        {
            $@"Received capabilities request
    ipAddress = {ipAddress}
    port = {int.Parse(context.QueryString("port"))}
    name = {context.QueryString("name")}".Info();

            return context.JsonResponse(new Dictionary<string, bool>
            {
                {"JOIN", true},
                {"HANGUP", true},
                {"STATUS", true},
                {"MUTE_MICROPHONE", true},
                {"CALENDAR_PUSH", true}
            });
        }

        [WebApiHandler(HttpVerbs.Get, "/{ipAddress}/status")]
        public bool Status(WebServer server, HttpListenerContext context, string ipAddress)
        {
            $@"Received status request
    ipAddress = {ipAddress}
    port = {int.Parse(context.QueryString("port"))}
    name = {context.QueryString("name")}".Info();

            return context.JsonResponse(new Dictionary<string, bool>
            {
                {"callActive", false},
                {"microphoneMuted", false}
            });
        }

        [WebApiHandler(HttpVerbs.Post, "/{ipAddress}/join")]
        public bool Join(WebServer server, HttpListenerContext context, string ipAddress)
        {
			var endpoint = GetEndpoint(context);

            $@"Received join request
    ipAddress = {ipAddress}
    dialString = {context.QueryString("dialString")}
    meetingId = {context.QueryString("meetingId")}
    passcode = {context.QueryString("passcode")}
    bridgeAddress = {context.QueryString("bridgeAddress")}
    endpoint = {endpoint}".Info();

            context.Response.StatusCode = (int)HttpStatusCode.NoContent;
            return true;
        }

        [WebApiHandler(HttpVerbs.Post, "/{ipAddress}/mutemicrophone")]
        public bool MuteMicrophone(WebServer server, HttpListenerContext context, string ipAddress)
        {
            var endpoint = GetEndpoint(context);

            $@"Received mutemicrophone request
    ipAddress = {ipAddress}
    endpoint = {endpoint}".Info();

            context.Response.StatusCode = (int)HttpStatusCode.NoContent;
            return true;
        }

        [WebApiHandler(HttpVerbs.Post, "/{ipAddress}/unmutemicrophone")]
        public bool UnmuteMicrophone(WebServer server, HttpListenerContext context, string ipAddress)
        {
            var endpoint = GetEndpoint(context);

            $@"Received unmutemicrophone request
    ipAddress = {ipAddress}
    endpoint = {endpoint}".Info();

            context.Response.StatusCode = (int)HttpStatusCode.NoContent;
            return true;
        }

        [WebApiHandler(HttpVerbs.Post, "/{ipAddress}/hangup")]
        public bool HangUp(WebServer server, HttpListenerContext context, string ipAddress)
        {
            var endpoint = GetEndpoint(context);

            $@"Received hangup request
    ipAddress = {ipAddress}
    endpoint = {endpoint}".Info();

            context.Response.StatusCode = (int)HttpStatusCode.NoContent;
            return true;
        }

        private static Endpoint GetEndpoint(HttpListenerContext context)
        {
            var endpoint = context.ParseJson<Endpoint>();
            var (username, password) = GetBasicCredentials(context);
            endpoint.username = username;
            endpoint.password = password;
            return endpoint;
        }

        private static (string username, string password) GetBasicCredentials(HttpListenerContext context)
        {
            const string prefix = "Basic ";
            var credentials = (username: "", password: "");
            var authHeader = context.RequestHeader("Authorization");
            if (authHeader.StartsWith(prefix, StringComparison.Ordinal))
            {
                var prefixRemoved = authHeader.Substring(prefix.Length);
                string decoded = Encoding.UTF8.GetString(Convert.FromBase64String(prefixRemoved));
                string[] split = decoded.Split(':', 2);
                credentials.username = split[0];
                credentials.password = split[1];
            }
            return credentials;
        }
    }
}