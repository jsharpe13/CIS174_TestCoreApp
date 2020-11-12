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
            var rep = new Mock<IRepository<Ticketing>>();
            //var mockContext = new Mock<StudentContext>();
            var controller = new TicketingController(rep.Object);

            //act
            var result = controller.ticketIndex("all-all");

            //assert
            Assert.IsType<ViewResult>(result);
        }
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
    }
}
