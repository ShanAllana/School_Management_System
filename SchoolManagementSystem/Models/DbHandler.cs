using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class DbHandler
    {
        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public static DataTable getTeachers()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("getTeachers", conn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            conn.Close();
            return dtbl;
        }

        public static DataTable getTdata()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("getTdata", conn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            conn.Close();
            return dtbl;
        }

        public static DataTable getFeeRecord()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("getFeeRecord", conn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            conn.Close();
            return dtbl;
        }

        public static DataTable getStudents()
        {
            

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("getStudents", conn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
           
            conn.Close();
            return dtbl;
        }

        public static DataTable getClasses()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("getClasses", conn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            conn.Close();
            return dtbl;
        }
        public static DataTable getTeacherCount()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("getTeacherCount", conn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            conn.Close();
            return dtbl;
        }
        public static DataTable getTeacherAttendance()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("getTeacherAttendance", conn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            conn.Close();
            return dtbl;
        }

        public static DataTable getSubject()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("getSubject", conn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            conn.Close();
            return dtbl;
        }


        public static int AddSubject(string subject_name, int class_id)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

           if (conn.State == ConnectionState.Closed)
               conn.Open();
           SqlCommand cmd = new SqlCommand("addSubject",conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@subject_name",subject_name);
           cmd.Parameters.AddWithValue("@class_id", class_id);
            cmd.Parameters.AddWithValue("@datetime", sqlFormattedDate);
           int result =  cmd.ExecuteNonQuery();
           conn.Close();

           return result;
            }

        public static int editsubject(string subject_name, int subject_id, int class_id)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");


            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("editsubject", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", subject_id);
            cmd.Parameters.AddWithValue("@subject_name", subject_name);
            //cmd.Parameters.AddWithValue("@datetime", sqlFormattedDate);
            cmd.Parameters.AddWithValue("@class_id", class_id);
            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public static int editstudent(string roll_no, string s_name, string f_name, String leaving_date, int student_id, int class_id)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            //String FormattedDate = Convert.ToDateTime(leaving_date).ToString("yyyy-MM-dd HH:mm:ss.fff");


            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("editstudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", student_id);
            cmd.Parameters.AddWithValue("@roll_no", roll_no);
            cmd.Parameters.AddWithValue("@s_name", s_name);
            cmd.Parameters.AddWithValue("@f_name", f_name);
            cmd.Parameters.AddWithValue("@class_id", class_id);
            if (leaving_date == "")
            {
                cmd.Parameters.AddWithValue("@leaving_date", DBNull.Value);
            }
            else
            {
                string FormattedDate = Convert.ToDateTime(leaving_date).ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@leaving_date", FormattedDate);
            }
            
            
            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public static int editteacher(int id ,string leaving_date, int class_id)
        {
           
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("editteacher", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            cmd.Parameters.AddWithValue("@class_id", class_id);
            
            if (leaving_date == "")
            {
                cmd.Parameters.AddWithValue("@leaving_date", DBNull.Value);
            }
            else
            {
                string FormattedDate = Convert.ToDateTime(leaving_date).ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@leaving_date", FormattedDate);
            }


            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }


        public static void deletesubject(int[] subject_id)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string mystr = "";
            for (int i = 0; i < subject_id.Length; i++)
            {
                mystr += subject_id[i];
                if (i < (subject_id.Length - 1))
                {
                    mystr += ",";
                }
            }
            SqlCommand cmd = new SqlCommand("delete from subject where id in (" + mystr + ")", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteClasses(int[] classes)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string mystr = "";
            for(int i=0;i<classes.Length;i++)
            {
                mystr += classes[i];
                if(i<(classes.Length-1))
                {
                    mystr += ",";
                }
            }

           

            SqlCommand cmd = new SqlCommand("delete from classes where id in ("+mystr+")", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deletestudent(int[] student)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string mystr = "";
            for (int i = 0; i < student.Length; i++)
            {
                mystr += student[i];
                if (i < (student.Length - 1))
                {
                    mystr += ",";
                }
            }



            SqlCommand cmd = new SqlCommand("delete from student where id in (" + mystr + ")", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteteacher(int[] teacher)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string mystr = "";
            for (int i = 0; i < teacher.Length; i++)
            {
                mystr += teacher[i];
                if (i < (teacher.Length - 1))
                {
                    mystr += ",";
                }
            }



            SqlCommand cmd = new SqlCommand("delete from teacher where id in (" + mystr + ")", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }



        public static int editClasses(string class_name,int fees ,int class_id)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");


            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("editclasses", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", class_id);
            cmd.Parameters.AddWithValue("@class_name", class_name);
            cmd.Parameters.AddWithValue("@fees", fees);
            cmd.Parameters.AddWithValue("@datetime", sqlFormattedDate);
            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public static int AddClass(string class_name, int fees)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("addClass", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@class_name", class_name);
            cmd.Parameters.AddWithValue("@fees", fees);
            cmd.Parameters.AddWithValue("@datetime", sqlFormattedDate);

            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }


        public static int AddStudent(string roll_no, string s_name, string f_name, int class_id)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("addStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@roll_no", roll_no);
            cmd.Parameters.AddWithValue("@s_name", s_name);
            cmd.Parameters.AddWithValue("@f_name", f_name);
            cmd.Parameters.AddWithValue("@class_id", class_id);
            cmd.Parameters.AddWithValue("@addmission_date", sqlFormattedDate);
           
            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public static int AddTeacher(int teacher_name, float salary, string email, int class_id)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("addTeacher", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@teacher_name", teacher_name);
           
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@email", email);

            cmd.Parameters.AddWithValue("@joining_date", sqlFormattedDate);

            cmd.Parameters.AddWithValue("@class_id", class_id);
            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }


        //public static int PunchIn(int t_id)
        //{

        //    t_id = 1;

        //    DateTime myDateTime = DateTime.Now;
        //    string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

        //    if (conn.State == ConnectionState.Closed)
        //        conn.Open();
        //    SqlCommand cmd = new SqlCommand("TPunchIn", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@t_id", t_id);

        //    cmd.Parameters.AddWithValue("@punchIn", sqlFormattedDate);

        //    int result = cmd.ExecuteNonQuery();
        //    conn.Close();

        //    return result;
        //}

        //public static int PunchOut()
        //{

        //    DateTime myDateTime = DateTime.Now;
        //    string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

        //    if (conn.State == ConnectionState.Closed)
        //        conn.Open();
        //    SqlCommand cmd = new SqlCommand("TPunchOut", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@punchOut", sqlFormattedDate);

        //    int result = cmd.ExecuteNonQuery();
        //    conn.Close();

        //    return result;

        //}


        internal static string GetEmployeeData(int EmpId)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select emp.email,c.salary from employee emp join [contract] c on emp.contract_id = c.contract_id where emp_id=" + EmpId + " and emp.dept_id = 25 ", conn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            conn.Close();

            string result="";
            foreach (DataRow row in dtbl.Rows)
            {
                result = Convert.ToString(row[0]) + ":" + Convert.ToString(row[1]);
                
            }
            return result;
        }
        

    
        internal static string GetClassData(int ClassId)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(student.id) as 'Total Student', fees,(COUNT(student.id) * fees) as 'Total Fee' FROM student join classes ON student.class_id = classes.id WHERE class_id = " + ClassId + "  GROUP BY fees ", conn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            conn.Close();

            string result="";
            foreach (DataRow row in dtbl.Rows)
            {
                result = Convert.ToString(row[0]) + ":" + Convert.ToString(row[1]) + ":" + Convert.ToString(row[2]);
                
            }
            return result;
        }

        public static int GenerateFeeSlip(int class_id,int class_fee , int student_count, decimal totalAmount ,string month  )
        {

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string leaving_date = "";
            int created_by = 10;
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            SqlCommand cmd = new SqlCommand("generateFeeSlip", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@created_date", sqlFormattedDate);
            cmd.Parameters.AddWithValue("@slip_no", InvoiceNumberGenerator());            
            cmd.Parameters.AddWithValue("@month", month);            
            cmd.Parameters.AddWithValue("@class_id", class_id);
            cmd.Parameters.AddWithValue("@created_by", created_by);
            cmd.Parameters.AddWithValue("@total_amount", totalAmount);
            cmd.Parameters.AddWithValue("@student_count", student_count);
            cmd.Parameters.AddWithValue("@class_fees", class_fee);

            if (leaving_date == "")
            {
                cmd.Parameters.AddWithValue("@accepted_date", DBNull.Value);
            }
            else
            {
                string FormattedDate = Convert.ToDateTime(leaving_date).ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@accepted_date", FormattedDate);
            }

            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public static int InvoiceNumberGenerator()
       {
           DbHandler dbhandler = new DbHandler();
           Random random = new Random();
           int invoiceno = random.Next(14,1000000);

           if (dbhandler.ExistsInDataBase(invoiceno))
           {
               InvoiceNumberGenerator();
           }

           return invoiceno;
       }

    internal bool ExistsInDataBase(int invoiceno)
       {
           if (conn.State == ConnectionState.Closed)
               conn.Open();
           int res = 0;
           SqlCommand cmd = new SqlCommand("checkfeeRandomNo", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@feeslipNo", invoiceno);
           SqlDataAdapter sd = new SqlDataAdapter(cmd);
           DataTable dt = new DataTable();

           
           sd.Fill(dt);
           

           foreach (DataRow dr in dt.Rows)
           {
               res = Convert.ToInt32(dr[0]);
           }

           if(res==1)
           {
               return true;
           }
           return false;
       }

        internal static int UserLogin(string Username, string Password)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            int res = 0;
            SqlCommand cmd = new SqlCommand("UserLoginForSMS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                res = Convert.ToInt32(dr[0]);
            }

            return res;
        }
    }
}