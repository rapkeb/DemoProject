using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserDemo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a username")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Please enter an email")]
        [EmailAddress]
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
