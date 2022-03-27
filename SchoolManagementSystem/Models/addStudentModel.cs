using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
	public class addStudentModel
	{
        public int student_id { get; set; }
        public string roll_no { get; set; }
        public string Student_name { get; set; }
        public string father_name { get; set; }
        public int class_id { get; set; }
        public DateTime addmission_date { get; set; }
        public Nullable< DateTime> leaving_date { get; set; }
	}
}