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
        public void Test_TicketingPointValue()
        {
            //arrange
            var tpv = new TicketingPointValue();
            tpv.pointValueId = "1";
            tpv.Name = "1";
            tpv.orderNum = 1;

            //act
            var testPointValue = tpv;

            //assert
            Assert.Equal("1", testPointValue.pointValueId);
            Assert.Equal("1", testPointValue.Name);
            Assert.Equal(1, testPointValue.orderNum);
        }
        [Fact]
        public void Test_TicketingStatus()
        {
            //arrange
            var ts = new TicketingStatus();
            ts.StatusId = "qa";
            ts.Name = "Quality Assurance";

            //act
            var testStatus = ts;

            //assert
            Assert.Equal("qa", testStatus.StatusId);
            Assert.Equal("Quality Assurance", testStatus.Name);
        }
        [Fact]
        public void Test_Ticketings()
        {
            //arrange
            var t = new Ticketing();
            t.SprintNumberId = 1;
            t.Name = "test";
            t.Description = "Unit Testing";
            t.pointValueId = "1";
            t.StatusId = "qa";

            //act
            var testTickeing = t;

            //assert
            Assert.Equal(1, testTickeing.SprintNumberId);
            Assert.Equal("test", testTickeing.Name);
            Assert.Equal("Unit Testing", testTickeing.Description);
            Assert.Equal("1", testTickeing.pointValueId);
            Assert.Equal("qa", testTickeing.StatusId);
        }
        [Fact]
        public void Test_UOW()
        {
            var mockContext = new Mock<StudentContext>();
            var unitOfWork = new TicketingUnitOfWork(mockContext.Object);

            unitOfWork.Save();

            mockContext.Verify(x => x.SaveChanges());
        }
        [Fact]
        public void Test_TicketingController()
        {
            var mockContext = new Mock<StudentContext>();
            var unitOfWork = new TicketingUnitOfWork(mockContext.Object);
            var output = new TicketingController(unitOfWork);

            Assert.NotNull(output.ViewBag);
        }
        [Fact]
        public void Test_TicketingController_filters()
        {
            var mockContext = new Mock<StudentContext>();
            var unitOfWork = new TicketingUnitOfWork(mockContext.Object);
            var output = new TicketingController(unitOfWork);
            string[] test = { "all", "all" };

            var result = output.ticketFilter(test);

            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
