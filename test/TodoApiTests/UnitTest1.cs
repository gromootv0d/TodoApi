using System;
using Xunit;
using TodoApi;
using TodoApi.Models;
using TodoApi.Controllers;
using Moq;

namespace TodoApiTests
{
    public class UnitTest1
    {
        private TodoContext sut;
        private readonly Mock<ITodoApiRepository> repository = new Mock<ITodoApiRepository>();
        [Fact]
        public void GetAnswerOk()
        {
            repository.Setup(m => m.GetTodoContext()).CallBase();
            var target = new TodoItemsController(sut);
            var result = target.GetTodoItems();
            Assert.NotNull(result);
        }
    }
}
