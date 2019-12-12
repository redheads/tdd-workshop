using NUnit.Framework;
using Playground.Domain;

namespace Playground
{
    [TestFixture]
    public class IntegrationDemos
    {
        // TODO adding new customer returns the number of customers
        // TODO adding new customer returns new id
        // TODO adding new customer returns new customer with id
    }

    public class CustomerChanger
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerChanger()
        {
            _customerRepository = new CustomerRepository();
        }

        void Add(Customer customer){}
    }

    public class CustomerProvider
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerProvider()
        {
            _customerRepository = new CustomerRepository();
        }

        Customer GetById(int customerId)
        {
            return new Customer
            {
                Id = 1
            };
        }
    }

    public class CustomerRepository
    {
        
    }
}