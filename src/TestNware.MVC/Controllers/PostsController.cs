using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestNware.Domain.Commands;
using TestNware.Domain.Contracts;
using TestNware.Domain.DomainNotification;
using TestNware.Domain.Queries;

namespace TestNware.Controllers
{
    public class PostsController : Controller
    {
        private readonly IProcessor _processor;
        private readonly INotificationContext _notificationContext;

        public PostsController(IProcessor processor, INotificationContext notificationContext)
        {
            _processor = processor;
            _notificationContext = notificationContext;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var newPost = new CreatePost
            {
                Categories = await _processor.Get(new GetCategoriesForDropdownList())
            };

            return View(newPost);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePost createPost)
        {
            _processor.Send(createPost);

            if (_notificationContext.HasNotifications())
            {
                var errors = _notificationContext.Notifications();

                errors.ToList().ForEach(error => ModelState.AddModelError(error.Key, error.Message));
                createPost.Categories = await _processor.Get(new GetCategoriesForDropdownList());
                return View(createPost);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _processor.Get(new GetPostForEdition(id));
            result.Categories = await _processor.Get(new GetCategoriesForDropdownList());

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPost editPost)
        {
            _processor.Send(editPost);

            if (_notificationContext.HasNotifications())
            {
                var errors = _notificationContext.Notifications();

                errors.ToList().ForEach(error => ModelState.AddModelError(error.Key, error.Message));
                editPost.Categories = await _processor.Get(new GetCategoriesForDropdownList());
                return View(editPost);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}