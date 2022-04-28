using Grpc.Core;

namespace GrpcService1.Services
{
    public class CustomersService : Customer.CustomerBase //Notice BASE
    {
        private readonly ILogger<CustomersService> logger;
        public CustomersService(ILogger<CustomersService> logger)
        {
            this.logger = logger;
        }

        public override async Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            CustomerModel output = new CustomerModel();

            if (request.UserId == 1)
            {
                output.FirstName = "Jamie";
                output.LastName = "Smith";
            }
            else if (request.UserId == 2)
            {
                output.FirstName = "Jane";
                output.LastName = "Doe";
            }
            else
            {
                output.FirstName = "Greg";
                output.LastName = "Thomas";
            }

            return await Task.FromResult(output);
        }

        public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            List<CustomerModel> customers = new List<CustomerModel>()
            {
                new CustomerModel()
                {
                    FirstName = "Rui",
                    LastName = "Vilela",
                    EmailAddress = "rui@t.pt",
                    Age =42,
                    IsAlive = true,
                },
                new CustomerModel()
                {
                    FirstName="Sue",
                    LastName="Storm",
                    EmailAddress="sue@t.pt",
                    Age=40,
                    IsAlive=false,
                },
                new CustomerModel()
                {
                    FirstName= "Bilbo",
                    LastName = "Beggins",
                    EmailAddress="bilbo@t.pt",
                    Age = 110,
                    IsAlive=false,
                }
            };

            foreach (var customer in customers)
            {
                await Task.Delay(1000); // simulated processing
                await responseStream.WriteAsync(customer);
            }
        }
    }
}
