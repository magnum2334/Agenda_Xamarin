using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.Models
{
    public class User
    {
        [AutoIncrement, PrimaryKey]
       
        public int Id { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }


    }
}
