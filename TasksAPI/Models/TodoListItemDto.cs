using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksAPI.Models
{
    public class TodoListItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TodoItemStatus Status { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TodoItemPriority Priority { get; set; }
        public string Href { get; set; }

    }
}
