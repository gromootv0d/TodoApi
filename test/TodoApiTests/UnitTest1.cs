using System;
using Xunit;
using TodoApi;
using TodoApi.Models;
using TodoApi.Controllers;
using Moq;
using TodoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace TodoApiTests
{
    public class UnitTest1
    {
        private TodoItemsController sut;
        private readonly Mock<ITodoApiRepository> repository = new Mock<ITodoApiRepository>();
        public UnitTest1()
        {
            this.sut = new TodoItemsController(this.repository.Object);
        }
        
        [Fact]
        public void GetAnswerNotNull()
        {   
            var result = this.sut.GetTodoItems();
            Assert.NotNull(result);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetAnswer404(long value)
        {
            var result = this.sut.GetTodoItem(value);
            Assert.Equal(404, ((StatusCodeResult)result.Result.Result).StatusCode);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetAnswer400(int id)
        {
            TodoItem item = new TodoItem();
            var result = this.sut.PutTodoItem(id, item);
            Assert.Equal(400, ((StatusCodeResult)result.Result).StatusCode);
        }
        public void GetAnswer415(int id)
        {
            //TodoItem item = new TodoItem();
            //var result = this.sut.PostTodoItem();
            //Assert.Equal(400, ((StatusCodeResult)result.Result).StatusCode);
        }
    }
}
