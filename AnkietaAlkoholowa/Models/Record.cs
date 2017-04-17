using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnkietaAlkoholowa.Models
{
    public class Record
    {
        public int Age { get; set; }
        public string Sex { get; set; }

        public Record()
        {
            
        }

        public Record(int age, string sex)
        {
            this.Age = age;
            this.Sex = sex;
        }
    }
}