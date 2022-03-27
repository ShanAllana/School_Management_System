using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class teacherattendanceviewModel
    {
        public int attendacne_id { get; set; }
        public int teacher_id { get; set; }
        public string teacher_name { get; set; }
        public DateTime punchIn { get; set; }
        public DateTime punchOut { get; set; }
    }
}