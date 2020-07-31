using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using To_Do_List.Models;

namespace To_Do_List.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ToDoItemController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok("test");
        }

        // returns list of to do items - /todoitem/List
        public IEnumerable<Models.ToDoItem> List()
        {
            return ToDoItemsMap.GetAllItems();
        }

        // returns a single todo item with id - /todoitem/get/<id>
        public ActionResult Get(int id)
        {
            var item = ToDoItemsMap.GetItemById(id);
            if (item == null)
            {
                return NotFound("To Do Item not found");
            }
            return Ok(item);
        }
    }
}