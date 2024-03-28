using Moq;
using Xunit;
using NewsForYou.Business;
using NewsForYou.Models;
using NewsForYou.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NewsForYou.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task TestLoginSuccess()
        {
            var mockService = new Mock<IService>();
            var controller = new NewsForYouController(mockService.Object);
            var testLoginModel = new LoginModel
            {
                Email = "admin@gmail.com",
                Password = "admin"
            };
            var expectedToken = "fake-jwt-token";

            mockService.Setup(s => s.Login(It.IsAny<LoginModel>()))
                .ReturnsAsync((true, expectedToken));


            var result = await controller.Login(testLoginModel);


            var okResult = Assert.IsType<OkObjectResult>(result);

            
            var resultValue = okResult.Value.GetType();
            var authenticateProperty = resultValue.GetProperty("authenticate");
            var jwtTokenProperty = resultValue.GetProperty("jwtToken");

            Assert.NotNull(authenticateProperty);
            Assert.NotNull(jwtTokenProperty);

            var authenticateValue = (bool)authenticateProperty.GetValue(okResult.Value);
            var jwtTokenValue = (string)jwtTokenProperty.GetValue(okResult.Value);

            Assert.True(authenticateValue);
            Assert.Equal(expectedToken, jwtTokenValue);

            
            mockService.Verify(s => s.Login(It.IsAny<LoginModel>()), Times.Once);
        }

        [Fact]
        public async Task GetCategory_ReturnsOkObjectResult_WithCategories()
        {
            
            var mockService = new Mock<IService>();
            var controller = new NewsForYouController(mockService.Object);
            var categories = new List<CategoryModel>
            {
                new CategoryModel { Id = 1, Title = "Sports" },
                new CategoryModel { Id = 2, Title = "Business" },
                new CategoryModel { Id = 3, Title = "Science" },
                new CategoryModel { Id = 4, Title = "Entertainment" }
            };

            mockService.Setup(s => s.GetCategory()).ReturnsAsync(categories);

            
            var actionResult = await controller.GetCategory();

            
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.NotNull(okResult.Value);

            
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(okResult.Value);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<CategoryModel>>>(json);

            Assert.NotNull(data);
            var returnedCategories = data["result"];
            Assert.Equal(categories.Count, returnedCategories.Count);

            for (int i = 0; i < returnedCategories.Count; i++)
            {
                Assert.Equal(categories[i].Id, returnedCategories[i].Id);
                Assert.Equal(categories[i].Title, returnedCategories[i].Title);
            }

            
            mockService.Verify(s => s.GetCategory(), Times.Once);
        }


        [Fact]
        public async Task GetAgency_ReturnsOkObjectResult_WithAgencies()
        {
            
            var mockService = new Mock<IService>();
            var controller = new NewsForYouController(mockService.Object);
            var agencies = new List<AgencyModel>
            {
                new AgencyModel { Id = 1, Name = "Times of India" },
                new AgencyModel { Id = 2, Name = "Hindustan Times" }
            };

            mockService.Setup(s => s.GetAgency()).ReturnsAsync(agencies);

            var actionResult = await controller.GetAgency();

            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            Assert.NotNull(okResult.Value);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(okResult.Value);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<AgencyModel>>>(json);

            Assert.NotNull(data);
            Assert.True(data.ContainsKey("result"), "Result key not found in response.");
            var returnedAgencies = data["result"];
            Assert.Equal(agencies.Count, returnedAgencies.Count);

            for (int i = 0; i < returnedAgencies.Count; i++)
            {
                Assert.Equal(agencies[i].Id, returnedAgencies[i].Id);
                Assert.Equal(agencies[i].Name, returnedAgencies[i].Name);
            }

            mockService.Verify(s => s.GetAgency(), Times.Once);
        }

        [Fact]
        public async Task GetCategoriesFromAgencyId_ReturnsOkObjectResult_WithCategories()
        {
            var mockService = new Mock<IService>();
            var controller = new NewsForYouController(mockService.Object);
            int agencyId = 1;

            var result = await controller.GetCategoriesFromAgencyId(agencyId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }


        [Fact]
        public async Task GetAllNews_ReturnsOkObjectResult_WithAllNews()
        {
            var mockService = new Mock<IService>();
            var controller = new NewsForYouController(mockService.Object);
            int categoryId = 1;
           
            var result = await controller.GetAllNews(categoryId);

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GeneratePdf_ReturnsOkObjectResult_WithReport()
        {
            
            var mockService = new Mock<IService>();
            var controller = new NewsForYouController(mockService.Object);
            var exportModel = new ExportModel
            {
                Start = DateTime.Now.AddDays(-7),
                End = DateTime.Now
            };

            
            var result = await controller.GeneratePdf(exportModel);

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetNewsByCategories_ReturnsOkObjectResult_WithNews()
        {
            
            var mockService = new Mock<IService>();
            var controller = new NewsForYouController(mockService.Object);
            var model = new GetNewsByCategoriesModel
            {
                Categories = new List<int> { 1, 2 },
                Id = 1
            };
            
            
            var result = await controller.GetNewsByCategories(model);

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task IncrementNewsClickCount_ReturnsOkObjectResult_WithFlag()
        {
            
            var mockService = new Mock<IService>();
            var controller = new NewsForYouController(mockService.Object);
            var id = 1;
            var flag = true;

            mockService.Setup(s => s.IncrementNewsClickCount(id)).ReturnsAsync(flag);

            
            var result = await controller.IncrementNewsClickCount(id);

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task FindEmail_ReturnsOkObjectResult_WithFlag()
        {
            
            var mockService = new Mock<IService>();
            var controller = new NewsForYouController(mockService.Object);
            var id = "test@example.com";
            var flag = false;

            mockService.Setup(s => s.FindEmail(id)).ReturnsAsync(flag);

            
            var result = await controller.FindEmail(id);

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }


    }
}
