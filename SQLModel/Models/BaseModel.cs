using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;

namespace SQLModel.Models
{
    public abstract class BaseModel
    {
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }

        public string CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public virtual ApplicationUser Creator { get; set; }

        public string ModifyId { get; set; }
        [ForeignKey("ModifyId")]
        public virtual ApplicationUser Modify { get; set; }
    }
}
