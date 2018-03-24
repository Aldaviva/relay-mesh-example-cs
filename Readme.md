Blue Jeans Relay Mesh Example Server in C#
==========================================

Mesh is an HTTP interface that allows [Blue Jeans Relay](http://bluejeans.com/features/relay) to integrate with otherwise unsupported Endpoints.

The Relay Listener Service can send commands like join and hangup to this custom Mesh server, which will use custom integration logic to cause the unsupported Endpoint to carry out the command.

See the [Relay API docs](https://relay.bluejeans.com/docs/mesh.html) for more details and API specifications.

## Requirements
- [Blue Jeans Relay account](http://bluejeans.com/features/relay#relay)
- [Microsoft .NET Core SDK 2](https://www.microsoft.com/net/download)

## Installation
    git clone https://github.com/Aldaviva/relay-mesh-example-cs.git
    cd relay-mesh-example-cs/relay-mesh-example-cs
    dotnet restore
    dotnet run 

The web server will compile and run, listening on port `6374`. Requests will be parsed and logged.

## Start coding

Check out the resource methods in `relay-mesh-example-cs/MeshController.cs`.

From here you can implement your own logic when different requests are handled.