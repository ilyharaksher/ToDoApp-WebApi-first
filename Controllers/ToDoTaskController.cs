using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp_WebApi.Data;
using ToDoApp_WebApi.Models;
using ToDoApp_WebApi.Models.Entities;

namespace ToDoApp_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly ApplicationContext dbContext;

        public ToDoTaskController(ApplicationContext DbContext)
        {
            this.dbContext = DbContext;
        }

        [HttpGet]
        public IActionResult GetAllToDoTasks()
        {
            var allTasks = dbContext.ToDoTasks.ToList();
            Console.WriteLine("использован гет контроллер");
            return Ok(allTasks);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetToDoTaskById(int id)
        {
            var toDoTask = dbContext.ToDoTasks.Find(id);

            if (toDoTask == null)
            {
                return NotFound("НИЧЕГО!!!!!!");
            }
            else
            {
                return Ok(toDoTask);
            }
        }

        [HttpPost]
        public IActionResult AddToDoTask(OnlyNameToDoTaskDTO addTaskDTO)
        {
            var newTask = new ToDoTask()
            {
                Name = addTaskDTO.Name,
                IsCompleted = false
            };

            dbContext.ToDoTasks.Add(newTask);
            dbContext.SaveChanges();
            Console.WriteLine("Использован пост контроллер");
            return Ok(newTask);
        }


        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateToDoTask(int id, OnlyNameToDoTaskDTO newNameTask)
        {
            var toDoTask = dbContext.ToDoTasks.Find(id);
            if (toDoTask == null)
            {
                return NotFound("НИЧЕГО!!!!!!");
            }
            else
            {
                toDoTask.Name = newNameTask.Name;
                dbContext.SaveChanges();
                return Ok(toDoTask);
            }
        }
    }
}
