using System;
using Xunit;
using TodoApi;
using TodoApi.Models;
using TodoApi.Controllers;
using Moq;
using TodoApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Collections.Generic;

namespace TodoApiTests
{
    public class TodoItemsControllerTest
    {
        private TodoItemsController sut;
        private readonly Mock<ITodoApiRepository> repository = new Mock<ITodoApiRepository>();
        public TodoItemsControllerTest()
        {
            this.sut = new TodoItemsController(this.repository.Object);
        }
        
        [Fact]
        public void GetTodoItemsShouldNotNullActionResult()
        {
            this.repository.Setup(c => c.GetTodoItems()).ReturnsAsync(new List<TodoItem>());
            var result = this.sut.GetTodoItems();
            Assert.NotNull(result);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetTodoItemShouldNotFoundStatusCode(long value)
        {
            var result = this.sut.GetTodoItem(value);
            Assert.Equal(404, ((StatusCodeResult)result.Result.Result).StatusCode);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void PutTodoItemShould400StatusCode(int id)
        {
            TodoItem item = new TodoItem();
            var result = this.sut.PutTodoItem(id, item);
            Assert.Equal(400, ((StatusCodeResult)result.Result).StatusCode);
        }
        [Fact]
        public void PostTodoTtemShould201StatusCode()
        {
            TodoItem item = new TodoItem();
            var result = this.sut.PostTodoItem(item);
            Assert.Equal(201, ((ObjectResult)result.Result.Result).StatusCode);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void DeleteTodoitemShould404StatusCode(int id)
        {
            var result = this.sut.DeleteTodoItem(id);
            Assert.Equal(404, ((StatusCodeResult)result.Result).StatusCode);
        }
    }
}
