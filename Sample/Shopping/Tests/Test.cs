using Moq;
using System;
using WebApp.Controllers;
using Xunit;

namespace Tests
{
    public class Test
    {
        [Fact]
        public void ControllerDataViewTest()
        {
            var ctrl = new Mock<HomeController>();
        }
    }
}
