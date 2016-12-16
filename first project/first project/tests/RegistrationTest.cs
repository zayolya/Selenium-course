using first_project.model;
using first_project.tests;
using NUnit.Framework;

namespace first_project
{
    [TestFixture]
    public class RegistrationTest : TestBase
    {
        [Test, TestCaseSource(typeof(DataProviders), "ValidCustomers")]
        
        public void RegisterUserTest(Customer customer)
        {
            app.RegisterNewCustomer(customer);

            app.Logout();

            app.Login(customer);

            app.Logout();
        }
    }
}
