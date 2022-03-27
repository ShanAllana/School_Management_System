using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagementSystem.Models;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public static teacherattendanceviewModel PE;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult classes()
        {
            return View();
        }
        public ActionResult student()
        {
            ViewBag.ListClass = new SelectList(ClassList(DbHandler.getClasses()), "class_id", "class_name");
            return View();
        }
        public ActionResult subject()
        {
            ViewBag.ListClass = new SelectList(ClassList(DbHandler.getClasses()), "class_id", "class_name");
            return View();
        }
        public ActionResult teacher()
        {
            ViewBag.Listemp = new SelectList(EmpList(DbHandler.getTdata()), "emp_id", "emp_name");
            ViewBag.ListClass = new SelectList(ClassList(DbHandler.getClasses()), "class_id", "class_name");
            return View();
        }

        public ActionResult GenerateFeeSlip()
        {
            ViewBag.ListClass = new SelectList(ClassList(DbHandler.getClasses()), "class_id", "class_name");

            return View();
        }

        [HttpPost]
        public ActionResult addteacher(addTeacherModel b, FormCollection form)
        {
            int empid = Convert.ToInt32(form["Listemp"].ToString());
            int id = Convert.ToInt32(form["ListClass"].ToString());
            TempData["result"] = DbHandler.AddTeacher(empid, Convert.ToInt32(form["inputsalaryname"]), form["inputemailname"].ToString(), id);
            ViewBag.ListClass = new SelectList(ClassList(DbHandler.getClasses()), b.class_id);
            ViewBag.Listemp = new SelectList(EmpList(DbHandler.getTdata()), b.emp_id);
            Response.Write("<script>alert('Teacher Enrolled')</script>");
            return RedirectToAction("teacher");
        }


        [HttpPost]
        public ActionResult GenerateFeeSlip(generateFeeSlipModel b, FormCollection form)
        {
            int id = Convert.ToInt32(form["ListClass"].ToString());
            string month = Convert.ToString(form["MonthList"].ToString());
            TempData["result"] = DbHandler.GenerateFeeSlip(id, Convert.ToInt32(form["classfee"]), Convert.ToInt32(form["totalstudent"]), Convert.ToDecimal(form["totalamount"]), month);
            ViewBag.ListClass = new SelectList(ClassList(DbHandler.getClasses()), b.class_id);
            return RedirectToAction("GenerateFeeSlip");
        }

        public ActionResult teacherattendance()
        {
            return View();
        }
        public ActionResult tviewattendance()
        {
            return View();
        }
        public ActionResult tviewdashboard()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }




        [HttpPost]
        public ActionResult addSubject(addSubjectModel b, FormCollection form)
        {
            int id = Convert.ToInt32(form["ListClass"].ToString());
            TempData["result"] = DbHandler.AddSubject(b.subject_name, id);
            ViewBag.ListClass = new SelectList(ClassList(DbHandler.getClasses()), b.class_id);
            Response.Write("<script>alert('Subject Added')</script>");
            return RedirectToAction("subject");
        }

        [HttpPost]
        public ActionResult editsubject(addSubjectModel b, FormCollection f)
        {

            int i = DbHandler.editsubject(f["subjectName"].ToString(), Convert.ToInt32(f["subjectId"]), Convert.ToInt32(f["ClassId"]));

            return RedirectToAction("subject");
        }

        [HttpPost]
        public ActionResult editstudent(addStudentModel b, FormCollection f)
        {

            int i = DbHandler.editstudent(f["RollNo"].ToString(), f["sName"].ToString(), f["FatherName"].ToString(), f["leavingDate"].ToString(), Convert.ToInt32(f["studentId"]), Convert.ToInt32(f["classId"]));

            return RedirectToAction("student");
        }
        [HttpPost]
        public ActionResult editteacher(addTeacherModel b, FormCollection f)
        {
            int i = DbHandler.editteacher(Convert.ToInt32(f["empId"]),f["ld"].ToString(), Convert.ToInt32(f["cid"]));
           return RedirectToAction("teacher");
        }

        [HttpPost]
        public ActionResult editClasses(addClassModel b, FormCollection f)
        {

            int i = DbHandler.editClasses(f["className"].ToString(), Convert.ToInt32(f["fs"]), Convert.ToInt32(f["classId"]));

            return RedirectToAction("classes");
        }
        //public static void Edit(int id)
        //{
        //     addClassModel classModel = null; 
        //    if (DbHandler.conn.State == ConnectionState.Closed)
        //        DbHandler.conn.Open();
        //    SqlDataAdapter sda = new SqlDataAdapter("getClasses", DbHandler.conn);
        //    DataTable dtbl = new DataTable();
        //    sda.Fill(dtbl);
        //    DbHandler.conn.Close();

        //     foreach (System.Data.DataRow row in dtbl.Rows)
        //    {
        //         if(id == Convert.ToInt32(row[0]))
        //         {
        //             classModel = new addClassModel { class_name = row[1].ToString() };

        //         }
        //    }

        //    //return View(classModel);
        //}


        [HttpPost]
        public void addClass(addClassModel b)
        {
            TempData["result"] = DbHandler.AddClass(b.class_name,b.fees);

            Response.Write("<script>alert('Class Added');window.location = 'classes';</script>");

        }
        private IEnumerable<addClassModel> ClassList(DataTable dataTable)
        {
            List<string> STR = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                yield return new addClassModel

                {
                    class_id = Convert.ToInt32(row[0]),
                    class_name = row[1].ToString()
                };
            }
        }

        private IEnumerable<addTeacherModel> EmpList(DataTable dataTable)
        {
            List<string> STR = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                yield return new addTeacherModel

                {
                    emp_id = Convert.ToInt32(row[0]),
                    emp_name = row[1].ToString(),
                   
                };
            }
        }

        [HttpPost]
        public ActionResult addStudent(addStudentModel b, FormCollection form)
        {
            int id = Convert.ToInt32(form["ListClass"].ToString());
           
            TempData["result"] = DbHandler.AddStudent(b.roll_no, b.Student_name, b.father_name, id);
            ViewBag.ListClass = new SelectList(ClassList(DbHandler.getClasses()), b.class_id);
            Response.Write("<script>alert('Student Enrolled')</script>");
            return RedirectToAction("student");
        }

       

        [HttpPost]
        public ActionResult DeleteClasses(int[] classIds)
        {
            DbHandler.deleteClasses(classIds);

            return RedirectToAction("classes");
        }

        [HttpPost]
        public ActionResult DeleteSubject(int[] subjectIds)
        {
            DbHandler.deletesubject(subjectIds);

            Response.Write("<script>alert('Subject Deleted')</script>");

            return RedirectToAction("subject");
        }

        [HttpPost]
        public ActionResult DeleteStudent(int[] studentIds)
        {
            DbHandler.deletestudent(studentIds);

            Response.Write("<script>alert('Student Deleted')</script>");

            return RedirectToAction("student");
        }


        [HttpPost]
        public ActionResult DeleteTeacher(int[] teacherIds)
        {
            DbHandler.deleteteacher(teacherIds);

            Response.Write("<script>alert('Teacher Deleted')</script>");

            return RedirectToAction("teacher");
        }

        //[HttpPost]
        //public void punchIn(teacherattendanceviewModel b)
        //{
        //    TempData["result"] = DbHandler.PunchIn(b.teacher_id);

        //    Response.Write("<script>alert('Punch In Succes');window.location = 'tviewattendance';</script>");

        //}
        //[HttpPost]
        //public void punchOut()
        //{
        //    TempData["result"] = DbHandler.PunchOut();

        //    Response.Write("<script>alert('Punch Out Succes');window.location = 'tviewattendance';</script>");

        //}

        //==========================================================


        public ActionResult PunchIn()
        {
            PE = new teacherattendanceviewModel();
            return View(PE);
        }

        // [EnableCors("*","*","*")]
        [HttpPost]
        public int AjaxMethod(teacherattendanceviewModel PE)
        {
            if (DbHandler.conn.State == ConnectionState.Closed)
                DbHandler.conn.Open();


            System.Web.HttpContext.Current.Application.Lock();
            int teacherID = Convert.ToInt32(System.Web.HttpContext.Current.Application["teacher_id"] = 1 + "");
            System.Web.HttpContext.Current.Application.UnLock();

            SqlCommand cmd = new SqlCommand("CTPE", DbHandler.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@teacher_id", teacherID);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            if (result == 0)
            {
                return 0;
            }
            else
            {
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                SqlCommand cmd1 = new SqlCommand("", DbHandler.conn);

                System.Web.HttpContext.Current.Application.Lock();
                cmd1.CommandText = "insert into teacherattendance (teacher_id , punchIn) values(" + teacherID + ", '" + sqlFormattedDate + "' ) SELECT SCOPE_IDENTITY()";
                System.Web.HttpContext.Current.Application["Attandance"] = "" + cmd1.ExecuteScalar();
                System.Web.HttpContext.Current.Application.UnLock();
                DbHandler.conn.Close();
                return 1;
            }

        }

        [HttpPost]
        public int PunchOutMethod(teacherattendanceviewModel PE)
        {


            if (DbHandler.conn.State == ConnectionState.Closed)
                DbHandler.conn.Open();

            System.Web.HttpContext.Current.Application.Lock();
            int teacherID = Convert.ToInt32(System.Web.HttpContext.Current.Application["teacher_id"] = 1 + "");
            System.Web.HttpContext.Current.Application.UnLock();

            SqlCommand cmd = new SqlCommand("CTPO", DbHandler.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@teacher_id", teacherID);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            if (result == 0)
            {
                return 0;
            }
            else

            //teacherattendanceviewModel a = new teacherattendanceviewModel()
            //{
            //    punchOut=sqlFormattedDate
            //};
            {
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                System.Web.HttpContext.Current.Application.Lock();
                int attendanceId = Convert.ToInt32(System.Web.HttpContext.Current.Application["Attandance"]);
                int teacherId = Convert.ToInt32(System.Web.HttpContext.Current.Application["teacher_id"]);

                System.Web.HttpContext.Current.Application.UnLock();
                SqlCommand cmd2 = new SqlCommand("", DbHandler.conn);
                cmd2.CommandText = "update teacherattendance set punchOut = '" + sqlFormattedDate + "' where   teacher_id = " + teacherId + " and attendance_id = (select MAX(attendance_id) from teacherattendance where teacher_id =" + teacherId + ")SELECT SCOPE_IDENTITY();";
                cmd2.ExecuteNonQuery();
                DbHandler.conn.Close();
                return 1;
            }



            //==========================================================




        }

        [HttpPost]
        public string getEmpDetails(int EmpId)
        {
            string res = DbHandler.GetEmployeeData(EmpId);
            return res;
        }
        [HttpPost]
        public string getClassDetails(int ClassId)
        {
            string res = DbHandler.GetClassData(ClassId);
            return res;
        }

        [HttpPost]
        public int LoginUser( string Username, string Password)
        {
            return DbHandler.UserLogin(Username,Password);
        }

    }
}