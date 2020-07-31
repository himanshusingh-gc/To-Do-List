using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace To_Do_List.Models
{
    public class ToDoItem
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }

        public ToDoItem(int id, int userId, string title, bool isComplete)
        {
            ID = id;
            UserId = userId;
            Title = title;
            IsComplete = isComplete;
        }
    }

    // class to store todo items in a dictionary
    static class ToDoItemsMap
    {
        private static Dictionary<int, ToDoItem> itemsMap;

        static ToDoItemsMap()
        {
            itemsMap = new Dictionary<int, ToDoItem>();
            itemsMap.Add(1, new ToDoItem(1, 1000, "To Do Item 1", true));
            itemsMap.Add(2, new ToDoItem(2, 1001, "To Do Item 2", true));
            itemsMap.Add(3, new ToDoItem(3, 1002, "To Do Item 3", true));
            itemsMap.Add(4, new ToDoItem(4, 1003, "To Do Item 4", true));
            itemsMap.Add(5, new ToDoItem(5, 1004, "To Do Item 5", false));
            itemsMap.Add(6, new ToDoItem(6, 1005, "To Do Item 6", false));
            itemsMap.Add(7, new ToDoItem(7, 1006, "To Do Item 7", false));
            itemsMap.Add(8, new ToDoItem(8, 1007, "To Do Item 8", false));
            itemsMap.Add(9, new ToDoItem(9, 1008, "To Do Item 9", false));
            itemsMap.Add(10, new ToDoItem(10, 1009, "To Do Item 10", false));
        }

        // method to get an item by id
        public static ToDoItem GetItemById(int id)
        {
            if (itemsMap.ContainsKey(id))
            {
                return itemsMap[id];    
            }
            return null;
        }

        // method to return array of all To Do items.
        public static List<ToDoItem> GetAllItems()
        {
            List<ToDoItem> items = new List<ToDoItem>();
            foreach (var item in itemsMap)
            {
                 items.Add(item.Value);
            }
            return items;
        }
    }
}