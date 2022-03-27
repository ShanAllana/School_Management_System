using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class addClassModel
    {
        public int class_id { get; set; }
        public string class_name { get; set; }
        public int fees { get; set; }
        public DateTime class_date { get; set; }


    }
}