using Bank;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankTests
{
    public class BankHandlerTests
    {

        [Fact]
        public void ShowBalance_ValidUserShouldWork()
        {
            // Arrange 
            string pin = "1234";
            UserHandler userHandler = new UserHandler();

            // Act
            userHandler.Login(pin);

            // Assert
            Assert.IsType<decimal>(BankHandler.ShowBalance(userHandler.CurrentUser));
        }

        [Fact]
        public void ShowBalance_NullUserShouldGiveExeption()
        {
            Assert.Throws<AuthenticationException>(() => BankHandler.ShowBalance(null));
        }

        [Fact]
        public void AddToBalance_ValidUserAndDecimalShouldWork()
        {
            // Arrange
            decimal balanceAdd = 123312;
            UserHandler user = new UserHandler();
            user.Login("1234");

            // Act
            var ex = Record.Exception(() => BankHandler.AddToBalance(user.CurrentUser, balanceAdd));

            // Assert
            Assert.Null(ex);
        }

        [Theory]
        [InlineData(12345)]
        [InlineData(458784151515)]
        [InlineData(1)]
        [InlineData(10.44578)]
        public void AddToBalance_ValidUserDecimalTests(decimal balanceAdd)
        {
            // Arrange
            UserHandler user = new UserHandler();
            user.Login("1234");

            // Act
            var ex = Record.Exception(() => BankHandler.AddToBalance(user.CurrentUser, balanceAdd));

            // Assert
            Assert.Null(ex);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-45454848415)]
        [InlineData(-878485154)]
        [InlineData(-0.5)]
        public void AddToBalance_InvalidDecimals(decimal balanceAdd)
        {
            // Arrange
            UserHandler user = new UserHandler();
            user.Login("1234");

            // Act
            Assert.Throws<InvalidOperationException>(() => BankHandler.AddToBalance(user.CurrentUser, balanceAdd));
        }

        [Fact]
        public void AddToBalance_DecimalZeroValue()
        {
            // Arrange
            decimal balanceAdd = 0;
            UserHandler user = new UserHandler();
            user.Login("1234");

            // Act
            Assert.Throws<InvalidOperationException>(() => BankHandler.AddToBalance(user.CurrentUser, balanceAdd));
        }

        [Fact]
        public void AddToBalance_NullUser()
        {
            // Arrange
            decimal balanceAdd = 10;

            // Act
            Assert.Throws<AuthenticationException>(() => BankHandler.AddToBalance(null, balanceAdd));
        }




        [Fact]
        public void WithdrawFromBalance_ValidUserAndDecimalShouldWork()
        {
            // Arrange
            decimal balanceAdd = 123312;
            UserHandler user = new UserHandler();
            user.Login("1234");

            // Act
            var ex_1 = Record.Exception(() => BankHandler.AddToBalance(user.CurrentUser, balanceAdd));
            var ex_2 = Record.Exception(() => BankHandler.WithdrawFromBalance(user.CurrentUser, (balanceAdd - 1)));

            // Assert
            Assert.Null(ex_1);
            Assert.Null(ex_2);
        }

        [Theory]
        [InlineData(12345)]
        [InlineData(1235487)]
        public void WithdrawFromBalance_ValidDecimals(decimal balanceAdd)
        {
            // Arrange
            UserHandler user = new UserHandler();
            user.Login("1234");

            // Act
            user.CurrentUser.Account.Balance = balanceAdd;

            var ex = Record.Exception(() => BankHandler.WithdrawFromBalance(user.CurrentUser, (balanceAdd - 1)));

            // Assert
            Assert.Null(ex);

        }


        [Theory]
        [InlineData(1)]
        [InlineData(1235487)]
        [InlineData(0)]
        [InlineData(-5054)]
        public void WithdrawFromBalance_CantWithdrawOverBalance(decimal balanceAdd)
        {
            // Arrange
            UserHandler user = new UserHandler();
            user.Login("1234");

            // Act
            user.CurrentUser.Account.Balance = balanceAdd;

            // Assert
            Assert.Throws<ArgumentException>("amount", () => BankHandler.WithdrawFromBalance(user.CurrentUser, (balanceAdd + 1)));
        }

        [Fact]
        public void WithdrawFromBalance_NullUserShouldThrowExeption()
        {
            // Arrange
            decimal balanceAdd = 1000;

            // Assert
            Assert.Throws<ArgumentException>("user", () => BankHandler.WithdrawFromBalance(null, (balanceAdd + 1)));

        }


    }
}
