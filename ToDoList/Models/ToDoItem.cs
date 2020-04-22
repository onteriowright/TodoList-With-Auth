using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int ToDoStatusId { get; set; }
        [Required]
        public ToDoStatus ToDoStatus { get; set; }
        public string ApplicationUserId { get; set; }
        [Required]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
