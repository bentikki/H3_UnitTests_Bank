using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Bank;
using System.Security.Authentication;

namespace BankTests
{
    public class UserHandlerTests
    {
        [Fact]
        public void Login_UserExistsShouldGiveTrue()
        {
            // Arrange 
            string pin = "1234";
            UserHandler userHandler = new UserHandler();

            // Act
            bool loggedIn = userHandler.Login(pin);

            // Assert
            Assert.True(loggedIn);
        }

        [Fact]
        public void Login_UserDoesNotExistShouldFail()
        {
            // Arrange 
            string pin = "asdasdasdasdadsadasdasd";
            UserHandler userHandler = new UserHandler();

            // Act
            bool loggedIn = userHandler.Login(pin);

            // Assert
            Assert.False(loggedIn);
        }


        [Theory]
        [InlineData("abc")]
        [InlineData("asdasdqweqe")]
        public void Login_PinInputText(string pin)
        {
            // Assert 
            UserHandler userHandler = new UserHandler();

            // Act
            bool loggedIn = userHandler.Login(pin);

            // Assert
            Assert.False(loggedIn);
        }

        [Fact]
        public void CurrentUser_NoUserSatShouldGiveExeption()
        {
            UserHandler userHandler = new UserHandler();

            Assert.Throws<InvalidCredentialException>( () => userHandler.CurrentUser );
        }


        [Fact]
        public void CurrentUser_NoUserLoggedinShouldGiveFalse()
        {
            UserHandler userHandler = new UserHandler();

            bool userLoggedIn = userHandler.LoggedIn();
            Assert.False(userLoggedIn);
        }

        [Fact]
        public void CurrentUser_UserLoggedinShouldGiveTrue()
        {
            // Arrange
            string pin = "1234";
            UserHandler userHandler = new UserHandler();

            // Act
            userHandler.Login(pin);
            bool userLoggedIn = userHandler.LoggedIn();

            // Assert
            Assert.True(userLoggedIn);
        }


    }
}
