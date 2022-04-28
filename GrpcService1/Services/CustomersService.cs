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

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
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

            return Task.FromResult(output);
        }
    }
}
