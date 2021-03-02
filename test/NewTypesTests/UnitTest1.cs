using System;
using Xunit;
using TodoApi;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace NewTypesTests
{
    public class UnitTest1
    {
        private HttpClient _client;

        public UnitTest1()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }


        [Theory]
        [InlineData("GET")]

        //тест на выдачу всех значений по api/TodoItems (получение статуса ок)
        //test to get OK /api/TodoItems/
        public async Task Test_TodoApi(string method)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/TodoItems/");
            //Act
            var response = await _client.SendAsync(request);
            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        //[Theory]
        //[InlineData("POST", "")]
        //public async Task Test_TodoApi_post(string method, string data)
        //{
        //    //Arrange
        //    var request = new HttpRequestMessage(new HttpMethod(method), $"/api/TodoItems/");
        //    TodoApi.Models.TodoItem datta = new TodoApi.Models.TodoItem { };
        //    request.Content = datta;
        //    //Act
        //    var response = await _client.SendAsync(request);
        //    //Assert
        //    response.EnsureSuccessStatusCode();
        //    Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        //}

        ////текст на выдачу по значению /api/TodoItems/{id} (получение статуса ok)
        //[Theory]
        //[InlineData("GET", 1)]
        //public async Task Test_TodoApi_id(string method, int? id = null)
        //{
        //    //Arrange
        //    var request = new HttpRequestMessage(new HttpMethod(method), $"/api/TodoItems/{id}");
        //    //Act
        //    var response = await _client.SendAsync(request);
        //    //Assert
        //    response.EnsureSuccessStatusCode();
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //}


    }
}
