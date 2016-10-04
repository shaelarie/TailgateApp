using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string TeamName { get; set; }
        public ICollection <User> Users { get; set; }
    }
}