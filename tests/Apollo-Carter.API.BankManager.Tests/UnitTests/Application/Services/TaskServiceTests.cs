using Apollo_Carter.API.BankManager.Application.Mappers;
using Apollo_Carter.API.BankManager.Application.Services;
using Apollo_Carter.API.BankManager.Domain.ApolloData;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;
using Apollo_Carter.API.BankManager.Domain.ApolloData.ValueObjects;
using Apollo_Carter.API.BankManager.Tests.UnitTests.Helpers;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Moq;
using OpenTracing;
using OpenTracing.Mock;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Apollo_Carter.API.BankManager.Tests.UnitTests.Application.Services
{
    public class TaskServiceTests
    {
        private readonly Mock<IAccountRepository> _mockTaskRepository = new Mock<IAccountRepository>();
        private readonly Mock<IApolloDataFactory> _mockTaskFactory = new Mock<IApolloDataFactory>();
        private readonly Mock<ITracer> _mockITracer = new Mock<ITracer>();
        private readonly Mock<IMediator> _mockIMediator = new Mock<IMediator>();
        private static readonly Mock<IHttpContextAccessor> _mockIHttpContextAccessor = new Mock<IHttpContextAccessor>();

        private readonly ApolloDataViewModelMapper _mockTaskViewModelMapper = new ApolloDataViewModelMapper(_mockIHttpContextAccessor.Object);

        [Fact]
        public async System.Threading.Tasks.Task Create_Success()
        {
            //Arrange
            _mockITracer.Setup(x => x.BuildSpan(It.IsAny<string>())).Returns(() => new MockSpanBuilder(new MockTracer(), ""));
            _mockIMediator.Setup(x => x.SendAsync<Account>(It.IsAny<CreateNewTaskCommand>(), null))
                .Returns(System.Threading.Tasks.Task.FromResult(TaskHelper.GetTask()));
            _mockIHttpContextAccessor.Setup(x => x.HttpContext).Returns(HttpContextHelper.GetHttpContext());

            //Act

            var taskService = new TaskService(_mockTaskRepository.Object, _mockTaskViewModelMapper, _mockITracer.Object, _mockTaskFactory.Object, _mockIMediator.Object);
            var result = await taskService.Create(TaskViewModelHelper.GetTaskViewModel());

            //Assert
            Assert.NotNull(result);

            Assert.Equal("Summary", result.Summary);
            Assert.Equal("Description", result.Description);

            Assert.NotNull(result.Id);
            Assert.NotNull(result.Description);

            _mockITracer.Verify(x => x.BuildSpan(It.IsAny<string>()), Times.Once);
            _mockIMediator.Verify(x => x.SendAsync<Account>(It.IsAny<CreateNewTaskCommand>(), null), Times.Once);
        }
    }
}
