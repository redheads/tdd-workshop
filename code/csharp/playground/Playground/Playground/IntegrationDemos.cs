using NSubstitute;
using NUnit.Framework;

namespace Playground
{
    [TestFixture]
    public class IntegrationDemos
    {
        [Test]
        public void Registering_a_valid_new_customer_sends_a_confirmation_mail()
        {
            // Arrange
            var mailer = Substitute.For<IMailer>();
            
            var validCustomer = new ValidCustomer();
            var sut = new RegistrationService(mailer);
            
            // Act
            sut.Register(validCustomer);
            
            // Assert
            mailer.Received().Send();
        }
    }

    public interface IMailer
    {
        void Send();
    }

    public class RegistrationService
    {
        private readonly IMailer _mailer;

        public RegistrationService(IMailer mailer)
        {
            _mailer = mailer;
        }

        public void Register(ValidCustomer validCustomer)
        {
            _mailer.Send();
        }
    }

    public class ValidCustomer
    {
    }
}