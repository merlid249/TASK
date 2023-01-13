using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using TASK.Data.Service;
using TASK.Models;

namespace TASK.Controllers
{
    public class TaskController : Controller
    {
        public readonly ITaskService _service;
        public TaskController(ITaskService service)
        {
            _service = service;
        }
    
        public IActionResult Index(string searching )
        {
            var allData = _service.GetAllTask(searching);


            return View(allData);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Name", "Description", "Status", "DeadLine")]Taskk taskk)
        {
            if(!ModelState.IsValid)
            {
                return View(taskk);
            }
            _service.AddtTask(taskk);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edito = _service.GetTaskById(id);
            if (edito == null) return View("Not Found");
            return View(edito);
            return View();
        }
        [HttpPost]
        public  IActionResult Edit(int id, [Bind("Id,Name,Description,Status,DeadLine")] Taskk taskk)
        {
            if (!ModelState.IsValid)
            {
                return View(taskk);
            }
            _service.UpgradeTask(id, taskk);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public  IActionResult Delete(int id)
        {
             _service.DeleteTask(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
