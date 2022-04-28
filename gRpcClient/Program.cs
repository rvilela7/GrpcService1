
using Grpc.Net.Client;
using GrpcService1;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("http://localhost:49160");
            var customerClient = new Customer.CustomerClient(channel);

            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                var clientRequested = new CustomerLookupModel() { UserId = rnd.Next(3) + 1 };
                var reply = await customerClient.GetCustomerInfoAsync(clientRequested);
                Console.WriteLine($"{reply.FirstName} {reply.LastName}");
            }
            Console.ReadLine();
        }
    }
}
