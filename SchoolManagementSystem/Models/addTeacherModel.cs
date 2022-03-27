using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class addTeacherModel
    {
        public int teacher_id { get; set; }
        public string teacher_name { get; set; }
        public string cnic { get; set; }
        public float salary { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime joining_date { get; set; }
        public DateTime leaving_date { get; set; }
        public int class_id { get; set; }
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string emp_email { get; set; }
    }
}