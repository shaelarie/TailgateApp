using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public DateTime EventDate { get; set; }
        public int EventRating { get; set; }
        public bool EventStatus { get; set; }
        public string EventComments { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}