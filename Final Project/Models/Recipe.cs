using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Final_Project.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        public DateTime Date { get; set; }
    }
}
