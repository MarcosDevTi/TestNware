using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestNware.Controllers;
using TestNware.Domain.Contracts;
using TestNware.Domain.Models;
using TestNware.Domain.Pagination;
using TestNware.Domain.Queries;
using TestNware.Domain.Queries.Models;
using Xunit;

namespace TestNware.NetCoreApi.Test.Controllers
{
    public class AdminControllerTest
    {
        private readonly IProcessor _fakeProcessor;
        public AdminControllerTest()
        {
            _fakeProcessor = A.Fake<IProcessor>();
        }
        [Fact]
        public async Task GetCategories_AssertReturnWithParams()
        {
            // Arrange
            var controller = new AdminController(_fakeProcessor);
            IQuery<PagedResult<Category>> fakeGet = null;
            var getCategories = new GetCategories
            {
                Skip = 5,
                Top = 10
            };
            var valueToReturn = new PagedResult<Category>(
                new List<Category> { 
                    new Category { Id = Guid.NewGuid(), Title = "test title" },
                    new Category { Id = Guid.NewGuid(), Title = "test title2" },
                }, 4, new Paging<Category>());

            A.CallTo(() => _fakeProcessor.Get(A<GetCategories>._))
                .Invokes( (IQuery<PagedResult<Category>> get) =>
                        {
                            fakeGet = get;
                        }).Returns(valueToReturn);

            // Action
            var result = await controller.GetCategories(getCategories);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            ((result as OkObjectResult).Value as PagedResult<Category>).Should().BeEquivalentTo(valueToReturn);
            fakeGet.Should().Be(getCategories);
        }

        [Fact]
        public async Task GetCategories_AssertReturnNoContent()
        {
            // Arrange
            var controller = new AdminController(_fakeProcessor);

            var getCategories = new GetCategories
            {
                Skip = 5,
                Top = 10
            };
            var valueToReturn = new PagedResult<Category>(
                new List<Category>(), 4, new Paging<Category>());

            A.CallTo(() => _fakeProcessor.Get(A<GetCategories>._))
                .Returns(valueToReturn);

            // Action
            var result = await controller.GetCategories(getCategories);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task GetPosts_AssertReturnWithParams()
        {
            // Arrange
            var controller = new AdminController(_fakeProcessor);
            IQuery<PagedResult<PostItemAdmin>> fakeGet = null;
            var getPosts = new GetPostsAdmin
            {
                Skip = 5,
                Top = 10
            };
            var valueToReturn = new PagedResult<PostItemAdmin>(
                new List<PostItemAdmin> {
                    new PostItemAdmin { Id = Guid.NewGuid(), Title = "test title" },
                    new PostItemAdmin { Id = Guid.NewGuid(), Title = "test title2" },
                }, 4, new Paging<PostItemAdmin>());

            A.CallTo(() => _fakeProcessor.Get(A<GetPostsAdmin>._))
                .Invokes((IQuery<PagedResult<PostItemAdmin>> get) =>
                {
                    fakeGet = get;
                }).Returns(valueToReturn);

            // Action
            var result = await controller.GetPosts(getPosts);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            ((result as OkObjectResult).Value as PagedResult<PostItemAdmin>).Should().BeEquivalentTo(valueToReturn);
            fakeGet.Should().Be(getPosts);
        }

        [Fact]
        public async Task GetPosts_AssertReturnNoContent()
        {
            // Arrange
            var controller = new AdminController(_fakeProcessor);
            var getPosts = new GetPostsAdmin
            {
                Skip = 5,
                Top = 10
            };
            var valueToReturn = new PagedResult<PostItemAdmin>(
                new List<PostItemAdmin> {
                }, 4, new Paging<PostItemAdmin>());

            A.CallTo(() => _fakeProcessor.Get(A<GetPostsAdmin>._))
                .Returns(valueToReturn);

            // Action
            var result = await controller.GetPosts(getPosts);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }
    }
}