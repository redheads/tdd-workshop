using System;
using FluentAssertions;
using NUnit.Framework;
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable MemberCanBeMadeStatic.Local

namespace Playground
{
    public class NamingConventions
    {
        private class Customer
        {
            public int? Id { get; set; }
        }
        
        private class CustomerProvider
        {
            // Don't do this
            // Use return types such as Result, Option, MayBe instead!
            // And: Don't use exceptions for control flow! 
            public Customer GetCustomerById(int? customerId) =>
                customerId.HasValue && customerId.Value > 0
                    ? new Customer {Id = customerId}
                    : null;

            public void CreateCustomer(Customer customer)
            {
                if (customer == null)
                {
                    throw new Exception("Customer is empty");    
                }
            }
        }

        [TestFixture]
        public class CustomerProviderTests
        {
            private class GetById
            {
                [Test]
                public void With_valid_id()
                {
                    // Arrange
                    var sut = new CustomerProvider();
                    
                    // Act
                    var result = sut.GetCustomerById(1);
                    
                    // Assert
                    result.Should().NotBeNull();
                }

                [TestCase(null)]
                [TestCase(0)]
                [TestCase(-1)]
                public void With_invalid_id_returns_null(int? customerId)
                {
                    // Arrange
                    var sut = new CustomerProvider();
                    
                    // Act
                    var result = sut.GetCustomerById(customerId);
                    
                    // Assert
                    result.Should().BeNull();
                }
            }

            private class CreateCustomer
            {
                [Test]
                public void With_missing_customer_throws()
                {
                    // Arrange
                    var sut = new CustomerProvider();
                    
                    // Act
                    Action action = () => sut.CreateCustomer(null);
                    
                    // Assert
                    action.Should()
                        .Throw<Exception>()
                        .WithMessage("Customer is empty");
                }

                [Test]
                public void With_valid_customer_does_not_throw()
                {
                    // Arrange
                    var sut = new CustomerProvider();
                    
                    // Act
                    Action action = () => sut.CreateCustomer(new Customer());
                    
                    // Assert
                    action.Should().NotThrow<Exception>();
                }
            }
        }
    }
}