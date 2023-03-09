using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MapSched.models
{
    public class Period
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string start_time { get; set; }
        public string title { get; set; }
        public string building { get; set; }
    }
}
