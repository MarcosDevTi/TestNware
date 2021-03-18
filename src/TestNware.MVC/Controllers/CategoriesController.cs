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
    public class CategoriesController : Controller
    {
        private readonly IProcessor _processor;
        private readonly INotificationContext _notificationContext;

        public CategoriesController(IProcessor processor, INotificationContext notificationContext)
        {
            _processor = processor;
            _notificationContext = notificationContext;
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateCategory createCategory)
        {
            _processor.Send(createCategory);

            if (_notificationContext.HasNotifications())
            {
                var errors = _notificationContext.Notifications();

                errors.ToList().ForEach(error => ModelState.AddModelError(error.Key, error.Message));
                return View(createCategory);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _processor.Get(new GetCategoryForEdition(id));
            return View(result);
        }

        [HttpPost("{id:guid}")]
        public IActionResult Edit(EditCategory editCategory)
        {
            _processor.Send(editCategory);

            if (_notificationContext.HasNotifications())
            {
                var errors = _notificationContext.Notifications();

                errors.ToList().ForEach(error => ModelState.AddModelError(error.Key, error.Message));
                return View(editCategory);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
