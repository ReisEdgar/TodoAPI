using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksAPI.Models
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TodoItemStatus Status { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TodoItemPriority Priority { get; set; }

        public TodoItemDto()
        {
            Status = TodoItemStatus.OPEN;
            Priority = TodoItemPriority.MEDIUM;

        }



    }
}
