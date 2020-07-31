using System.Collections.Generic;
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

    static class ToDoItemsMap
    {
        private static Dictionary<int, ToDoItem> itemsMap;

        static ToDoItemsMap()
        {
            itemsMap = new Dictionary<int, ToDoItem>();
            itemsMap.Add(1, new ToDoItem(1, 1000, "To Do Item 1", false));
            itemsMap.Add(2, new ToDoItem(2, 1001, "To Do Item 2", false));
            itemsMap.Add(3, new ToDoItem(3, 1002, "To Do Item 3", false));
            
        }

        public static ToDoItem GetItemById(int id)
        {
            if (itemsMap.ContainsKey(id))
            {
                return itemsMap[id];    
            }

            return null;
        }
    }
    
    
}