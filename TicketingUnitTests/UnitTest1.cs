using CIS174_TestCoreApp.Controllers;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Moq;

namespace TicketingUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_index()
        {
            //arrange
            var rep = new FakeTicketingRepository();
            //var mockContext = new Mock<StudentContext>();
            var controller = new TicketingController(rep);

            //act
            var result = controller.ticketIndex("all-all");

            //assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
