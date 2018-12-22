using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace SQLLite.Models
{
    [Table("people")]
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250), Unique]
        public string Name { get; set; }
    }
}
