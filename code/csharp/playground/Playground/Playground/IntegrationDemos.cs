using NUnit.Framework;
using Playground.Domain;

namespace Playground
{
    [TestFixture]
    public class IntegrationDemos
    {
        // TODO
    }

    public class CustomerChanger
    {
        void Add(Customer customer){}
    }

    public class CustomerProvider
    {
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