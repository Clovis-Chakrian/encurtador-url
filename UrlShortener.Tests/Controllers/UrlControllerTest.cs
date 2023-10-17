using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Controllers;
using UrlShortener.Models;
using UrlShortener.Repository;
using Xunit;

namespace UrlShortener.Tests.Controllers
{
    public class UrlControllerTest
    {
        [Fact]
        public async Task GetUrl_Returns_Lis_Of_Saved_Urls()
        {
            // Arrange
            int count = 3;
            var fakeUrls = A.CollectionOfDummy<Url>(count).AsEnumerable();
            var dataStore = A.Fake<IUrlRepository>();
            A.CallTo(() => dataStore.SearchUrls()).Returns(Task.FromResult(fakeUrls));
            var controller = new UrlController(dataStore);
            
            // Act
            var actionResult = await controller.Get();
            
            // Assert
            var result = actionResult as OkObjectResult;
            var returnUrls = result.Value as IEnumerable<Url>;
            Assert.Equal(count, returnUrls.Count());
        }
    }
}