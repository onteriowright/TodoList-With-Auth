using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ToDoStatus
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Todo Status")]
        public string Title { get; set; }
    }
}
