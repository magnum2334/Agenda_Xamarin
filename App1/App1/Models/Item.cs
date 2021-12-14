using System;
using SQLite;

namespace App1.Models
{
    public class Item
    {
        [AutoIncrement, PrimaryKey]
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}