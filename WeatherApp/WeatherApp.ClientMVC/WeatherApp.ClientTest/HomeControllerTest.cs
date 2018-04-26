using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WeatherApp.ClientMVC.Controllers;
using WeatherApp.ClientMVC.Models;
using Xunit;

namespace WeatherApp.ClientTest
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void About()
        {
            // Assemble
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.About() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void LoginActionReturnsLoginView()
        {
            // Assemble
            HomeController controller = new HomeController();
            // Act
            var result = controller.Login() as RedirectToActionResult;
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            // Assert
            Assert.NotNull(result);
            Assert.False(result.Permanent);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("Login", redirectToActionResult.ControllerName);
        }

        [Fact]
        public void Error()
        {
            /**
            // Assemble
            HomeController controller = new HomeController();
            ErrorViewModel evm = new ErrorViewModel();
            // Act
            ViewResult result = controller.Error() as ViewResult;
            // Assert
            Assert.NotNull(result);
            */
        }
    }
}
