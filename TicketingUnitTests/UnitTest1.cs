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
        /*
        [Fact]
        public void Test_index()
        {
            //arrange
            var IUnit = new Mock<ITicketingUnitOfWork>();
            var controller = new TicketingController(IUnit.Object);

            //act
            var result = controller.ticketIndex("all-all");
            

            //assert
            Assert.IsType<ViewResult>(result);
        }
        */
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
        /*
        [Fact]
        public void Test_edit()
        {
            //arrange
            var rep = new Mock<IRepository<Ticketing>>();
            //var mockContext = new Mock<StudentContext>();
            var controller = new TicketingController(rep.Object);

            //act
            var result = controller.ticketEdit("all-all", new Ticketing());

            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact]
        public void Test_filter()
        {
            //arrange
            var rep = new Mock<IRepository<Ticketing>>();
            //var mockContext = new Mock<StudentContext>();
            var controller = new TicketingController(rep.Object);
            string[] test = { "all", "all" };

            //act
            var result = controller.ticketFilter(test);

            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact]
        public void Test_add_view()
        {
            //arrange
            var rep = new Mock<IRepository<Ticketing>>();
            //var mockContext = new Mock<StudentContext>();
            var controller = new TicketingController(rep.Object);

            //act
            var result = controller.ticketAdd();

            //assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Test_add_post()
        {
            //arrange
            var rep = new Mock<IRepository<Ticketing>>();
            //var mockContext = new Mock<StudentContext>();
            var controller = new TicketingController(rep.Object);

            //act
            var result = controller.ticketAdd(new Ticketing());

            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact]
        public void Test_add_post_details()
        {
            //arrange
            var rep = new Mock<IRepository<Ticketing>>();
            //var mockContext = new Mock<StudentContext>();
            var controller = new TicketingController(rep.Object);
            var addnew = new Ticketing();

            //act
            var result = controller.ticketAdd(addnew);

            //assert
            Assert.IsType<Ticketing>(addnew);
        }
        */
    }
}
