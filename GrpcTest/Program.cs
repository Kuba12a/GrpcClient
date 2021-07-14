using System;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcTest
{
    class Program
    {
        static async Task Main(string[] args)
        {

            AppContext.SetSwitch(
    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

          var channel = GrpcChannel.ForAddress("http://localhost:5000");

           var client = new Greeter.GreeterClient(channel);

            var clientRequested = new HelloRequest { Name = "aa" };



            var person = await client.SayHelloAsync(clientRequested);

            Console.WriteLine(person.Message);

            var client2 = new Customer.CustomerClient(channel);

            var clientRequested2 = new CustomerLookupModel { UserId = 1};

            var person2 = await client2.GetCustomerInfoAsync(clientRequested2);

            Console.WriteLine(person2.FirstName);

            Console.ReadLine();
        }
    }
}
