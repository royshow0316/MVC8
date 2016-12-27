using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SQLModel.Models;

namespace MVC.Models
{
    public class Project : BaseModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Structure> Structure { get; set; }
    }
}