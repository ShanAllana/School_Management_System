using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class addSubjectModel
    {
        public int subject_id { get; set; }
        public string subject_name { get; set; }
        public DateTime subject_date { get; set; }
        public int class_id { get; set; }

    }
}