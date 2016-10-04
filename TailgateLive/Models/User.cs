using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int UserZipCode { get; set; }
        public int UserRating { get; set; }
        [ForeignKey ("ApplicationUsers")]
        public string EmailId { get; set; }
        public ApplicationUser ApplicationUsers { get; set; }
        public ICollection <Event> Events { get;set; }
        public ICollection <Team> Teams { get; set; }


    }
}