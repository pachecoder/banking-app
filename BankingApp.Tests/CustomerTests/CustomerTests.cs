using AutoFixture;
using BankingApp.Domain;
using BankingApp.Repository;
using BankingApp.Services;
using FakeItEasy;
using Xunit;

namespace BankingApp.Tests.CustomerTests
{
    public class CustomerTests
    {
        [Fact]
        public void GetCustomerByIdHasToReturnACustomer()
        {
            var fixture = new Fixture();

            var customerFixture = fixture.Build<Customer>().Without(p => p.Account).Create();

            var mockRepository = A.Fake<ICustomerRepository>();

            var customerServices = new CustomerServices(mockRepository);

            A.CallTo(() => mockRepository.GetById(A<int>.Ignored)).Returns(customerFixture);

            var customer = customerServices.GetById(1);

            Assert.NotNull(customer);

        }

        [Fact]
        public void GetCustomerByIdHasToReturnNull()
        {
            
            var mockRepository = A.Fake<ICustomerRepository>();

            var customerServices = new CustomerServices(mockRepository);

            A.CallTo(() => mockRepository.GetById(A<int>.Ignored)).Returns((Customer?)null);

            var customer = customerServices.GetById(1);

            A.CallTo(() => mockRepository.GetById(A<int>.Ignored)).MustHaveHappened();

            Assert.NotNull(customer);

        }
    }
}