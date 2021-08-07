using JWTTokenTest.Controllers;
using JWTTokenTest.Models;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class TokenServiceTest
    {
        [Test]
        public void Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Username = "admin";
            loginViewModel.Password = "123";
            var tokenService = new TokenService();
            bool valid = tokenService.ValidUser(loginViewModel);

            Assert.True(valid);            
        }

        [Test]
        public void PasswordIsTooLong()
        {
            var _userService = new UserService();
            string password = "12345";

            bool isTooLong = _userService.ValidPasswordLength(password);

            Assert.True(isTooLong);
        }
    }
}