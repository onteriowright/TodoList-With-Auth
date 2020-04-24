using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Models.ViewModels;

namespace ToDoList.Controllers
{
    public class TodoItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public TodoItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        public async Task<ActionResult> Index(string filter)
        {
            var user = await GetCurrentUserAsync();
            var items = await _context.ToDoItem
                .Where(ti => ti.ApplicationUserId == user.Id)
                .Include(ti => ti.ToDoStatus)
                .ToListAsync();

            switch (filter)
            {
                case "To Do":
                    items = await _context.ToDoItem
                        .Where(ti => ti.ApplicationUserId == user.Id)
                        .Where(ti => ti.ToDoStatusId == 2)
                        .Include(ti => ti.ToDoStatus)
                        .ToListAsync();
                    break;
                case "Progress":
                    items = await _context.ToDoItem
                        .Where(ti => ti.ApplicationUserId == user.Id)
                        .Where(ti => ti.ToDoStatusId == 3)
                        .Include(ti => ti.ToDoStatus)
                        .ToListAsync();
                    break;
                case "Done":
                    items = await _context.ToDoItem
                        .Where(ti => ti.ApplicationUserId == user.Id)
                        .Where(ti => ti.ToDoStatusId == 4)
                        .Include(ti => ti.ToDoStatus)
                        .ToListAsync();
                    break;
                case "All":
                    items = await _context.ToDoItem
                        .Where(ti => ti.ApplicationUserId == user.Id)
                        .Include(ti => ti.ToDoStatus)
                        .ToListAsync();
                    break;
                default:
                    items = await _context.ToDoItem
                        .Where(ti => ti.ApplicationUserId == user.Id)
                        .Include(ti => ti.ToDoStatus)
                        .ToListAsync();
                    break;
            }
            return View(items);
        }

        // GET: TodoItems/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodoItems/Create
        public async Task<ActionResult> Create()
        {
            var allStatuses = await _context.ToDoStatus
              .Select(td => new SelectListItem()
              {
                  Text = td.Title,
                  Value = td.Id.ToString()
              })
              .ToListAsync();

            var viewModel = new ToDoStatusViewModel();

            viewModel.ToDoStatusOptions = allStatuses;

            return View(viewModel);
        }

        // POST: TodoItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDoStatusViewModel item)
        {
            try
            {
                var todoItem = new ToDoItem()
                {
                    Title = item.Title,
                    ToDoStatusId = item.ToDoStatusId
                };

                var user = await GetCurrentUserAsync();
                todoItem.ApplicationUserId = user.Id;

                _context.ToDoItem.Add(todoItem);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: TodoItems/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var allStatuses = await _context.ToDoStatus
              .ToListAsync();

            var todoItem = _context.ToDoItem
                .FirstOrDefault(ti => ti.Id == id);

            var viewModel = new ToDoStatusViewModel()
            {
                Title = todoItem.Title,
                ToDoStatusId = todoItem.ToDoStatusId,
                ToDoStatusOptions = allStatuses
                .Select(td => new SelectListItem()
                {
                    Text = td.Title,
                    Value = td.Id.ToString()
                }).ToList()
            };
            return View(viewModel);
        }

        // POST: TodoItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ToDoStatusViewModel item)
        {
            try
            {
                var user = await GetCurrentUserAsync();

                var todoItem = new ToDoItem()
                {
                    Id = id,
                    Title = item.Title,
                    ToDoStatusId = item.ToDoStatusId,
                    ApplicationUserId = user.Id
                };

                if (item.ApplicationUserId != user.Id)
                {
                    return NotFound();
                }

                _context.ToDoItem.Update(todoItem);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: TodoItems/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var todoItem = await _context.ToDoItem
                .Include(ti => ti.ToDoStatus)
                .FirstOrDefaultAsync(ti => ti.Id == id);

            return View(todoItem);
        }

        // POST: TodoItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ToDoItem item)
        {
            try
            {
                _context.ToDoItem.Remove(item);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


    }
}