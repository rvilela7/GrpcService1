using Grpc.Net.Client;
using GrpcService1;
using System;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("http://localhost:49154/");
            var client = new Greeter.GreeterClient(channel);
            var input = new HelloRequest { Name = "Maria" };
            var reply = await client.SayHelloAsync(input);

            Console.WriteLine(reply.Message);

            Console.ReadLine();
        }
    }
}

// Nuggets
// Google.protobuf
// Grpc.net.client
// Grpc.tools

// Property files for *proto (Client only)