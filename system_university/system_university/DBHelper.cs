using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace system_university
{
    public class DBHelper
    {
        public static string ConnectionString { get; } = "Data Source=DINA\\DINA;Initial Catalog=system_university;Integrated Security=True;TrustServerCertificate=True;";



        //max id

        public int GetMaxId(string tableName, string idColumn)
        {
            // يجب التحقق من صحة المدخلات
            if (string.IsNullOrWhiteSpace(tableName)) throw new ArgumentException("Table name cannot be empty");
            if (string.IsNullOrWhiteSpace(idColumn)) throw new ArgumentException("ID column cannot be empty");

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = $"SELECT ISNULL(MAX({idColumn}), 0) +1 FROM  {tableName}";
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar();
            }
        }


        //insert   ADD
        public void AddStudent(Student s)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"INSERT INTO  Students 
                                        (st_id, st_name, st_phone, st_email, st_birth_of_date, st_gender, st_address)
                                        VALUES (@id, @name, @phone, @email, @birth_of_date, @gender, @address)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", GetMaxId("Students", "st_id"));
                cmd.Parameters.AddWithValue("@name", s.Name);
                cmd.Parameters.AddWithValue("@phone", s.Phone);
                cmd.Parameters.AddWithValue("@email", s.Email);
                cmd.Parameters.AddWithValue("@birth_of_date", s.Birthdate);
                cmd.Parameters.AddWithValue("@gender", s.Gender);
                cmd.Parameters.AddWithValue("@address", s.Address);
                cmd.ExecuteNonQuery();
            }
        }

        //update
        public void UpdateStudent(Student s)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"UPDATE  Students 
                                    SET st_name=@name, st_phone=@phone, st_email=@email,
                                    st_birth_of_date=@birth, st_gender=@gender, st_address=@address
                                    WHERE st_id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", s.Id);
                cmd.Parameters.AddWithValue("@name", s.Name);
                cmd.Parameters.AddWithValue("@phone", s.Phone);
                cmd.Parameters.AddWithValue("@email", s.Email);
                cmd.Parameters.AddWithValue("@birth", s.Birthdate);
                cmd.Parameters.AddWithValue("@gender", s.Gender);
                cmd.Parameters.AddWithValue("@address", s.Address);
                cmd.ExecuteNonQuery();
            }
        }
        //delete
        public void DeleteStudent(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM Students WHERE st_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        //all student
        public DataTable GetAllStudents()
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
                string query = @"SELECT st_id,
                                   st_name AS Name,
                                   st_phone AS Phone,
                                   st_email AS Email,
                                   st_address AS Address,
                                   st_birth_of_date AS BirthDate,
                                   CASE WHEN st_gender = 1 THEN 'Male' ELSE 'Female' END AS Gender
                            FROM Students
                            ";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //search student 
        public DataTable SearchStudent(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                //   الاستعلام يشمل البحث بالاسم أو ID
                string query = @"SELECT st_id, st_name AS Name, st_phone AS Phone, st_email AS Email, st_birth_of_date AS BirthDate, st_address AS Address,
                                CASE WHEN st_gender = 1 THEN 'Male' ELSE 'Female' END AS Gender
                                FROM Students
                                WHERE st_id = @id OR st_name LIKE @key";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");
                if (int.TryParse(keyword, out int st_id))
                {
                    cmd.Parameters.AddWithValue("@id", st_id);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id", DBNull.Value);
                }
                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public static DataTable GetData(string query)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



        // دالة ترجع قيمة واحدة (مثلا عدد الطلاب)
        public static object ExecuteScalar(string query)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            return result;
        }



        //======================
        //=======

        // staff

        // LoadDepartments داخل ComboBox

        public DataTable LoadDepartments()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "SELECT d_code AS Code, d_name AS DepartmentName FROM Departments";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // LoadPositions
        public DataTable LoadPositions()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "SELECT stf_p_id, position_name FROM Staff_Position";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // GetAllStaff
        public DataTable GetAllStaff()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = @"
                                SELECT s.s_id, s.s_name as name, s.s_phone as phone, s.s_email as email, s.s_salary as salary, s.hire_date,
                                s.d_code, s.stf_p_id,
                                d.d_name AS department,
                                t.position_name AS position
                                FROM  Staff s
                                JOIN  Departments d ON s.d_code = d.d_code
                                JOIN  Staff_Position t ON s.stf_p_id = t.stf_p_id";
        SqlDataAdapter da = new SqlDataAdapter(query, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
}


        // SearchStaff
        public DataTable SearchStaff(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = @" SELECT
                                    s.s_id, s.s_name as name, s.s_phone as phone, s.s_email as email, s.s_salary as salary, s.hire_date,
                                    d.d_name AS Department,
                                    p.position_name AS Position
                                    FROM Staff s
                                    JOIN Departments d ON s.d_code = d.d_code
                                    JOIN Staff_Position p ON s.stf_p_id = p.stf_p_id
                                    WHERE s.s_name LIKE @key OR s.s_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");
                int.TryParse(keyword, out int id);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Check If Position Exists
        public bool CheckIfPositionExists(int stf_p_id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(1) FROM Staff_Position WHERE stf_p_id = @stf_p_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@stf_p_id", stf_p_id);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        //AddStaff
        public void AddStaff(Staff stf)
        {
            // تحقق أولاً من وجود d_code في جدول Departments
            if (stf == null) throw new ArgumentNullException(nameof(stf));

            // يجب التحقق من وجود المنصب أيضا
            bool isPositionExists = CheckIfPositionExists(stf.stf_p_id);
            if (!isPositionExists)
            {
                MessageBox.Show("The position does not exist.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"INSERT INTO  Staff 
                                    (s_id, s_name, s_phone, s_email, s_salary, hire_date, d_code, stf_p_id)
                                    VALUES (@s_id, @name, @phone, @email, @salary, @hire_date, @d_code, @stf_p_id)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@s_id", stf.s_id); // بس في الاستعلام @s_id
                cmd.Parameters.AddWithValue("@name", stf.s_name);
                cmd.Parameters.AddWithValue("@phone", stf.s_phone);
                cmd.Parameters.AddWithValue("@email", stf.s_email);
                cmd.Parameters.AddWithValue("@salary", stf.s_salary);
                cmd.Parameters.AddWithValue("@hire_date", stf.hire_date);
                cmd.Parameters.AddWithValue("@d_code", stf.d_code);
                cmd.Parameters.AddWithValue("@stf_p_id", stf.stf_p_id);
                cmd.ExecuteNonQuery();
            }
        }

        public bool CheckIfDepartmentExists(int d_code)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(1) FROM  Departments WHERE d_code = @d_code";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@d_code", d_code);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }


        // UpdateStaff
        public void UpdateStaff(Staff stf)
        {
            if (stf == null) throw new ArgumentNullException(nameof(stf));

            // تحقق من القسم
            bool deptExists = CheckIfDepartmentExists(stf.d_code);
            if (!deptExists)
            {
                MessageBox.Show("The department does not exist.");
                return;
            }

            // تحقق من المنصب
            bool positionExists = CheckIfPositionExists(stf.stf_p_id);
            if (!positionExists)
            {
                MessageBox.Show("The position does not exist.");
                return;
            }
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = @"UPDATE  Staff 
                                    SET s_name=@name, s_phone=@phone, s_email=@email,
                                    s_salary=@salary, hire_date=@hire_date,
                                    d_code=@d_code, stf_p_id=@stf_p_id
                                    WHERE s_id=@s_id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@s_id", stf.s_id);
                cmd.Parameters.AddWithValue("@name", stf.s_name);
                cmd.Parameters.AddWithValue("@phone", stf.s_phone);
                cmd.Parameters.AddWithValue("@email", stf.s_email);
                cmd.Parameters.AddWithValue("@salary", stf.s_salary);
                cmd.Parameters.AddWithValue("@hire_date", stf.hire_date);
                cmd.Parameters.AddWithValue("@d_code", stf.d_code);
                cmd.Parameters.AddWithValue("@stf_p_id", stf.stf_p_id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        //DeleteStaff
        public void DeleteStaff(int s_id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "DELETE FROM Staff WHERE s_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", s_id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //**********************
        //student details
        //**********************

        public List<StudentExamInfo> GetStudentExamInfo(int studentId)
        {
            List<StudentExamInfo> list = new List<StudentExamInfo>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = @"
                                    SELECT 
                                        s.st_name AS StudentName,
                                        d.d_name AS DepartmentName,
                                        c.c_name AS CourseName,
                                        c.c_credit AS CourseCredit,
                                        e.ex_type AS ExamType,
                                        e.ex_date AS ExamDate,
                                        g.grade AS Grade
                                    FROM  Registration r
                                    JOIN  Courses c ON r.c_code = c.c_code
                                    JOIN  Grades g ON g.c_code = c.c_code
                                    JOIN  Students s ON s.st_id = g.st_id
                                    JOIN  Exams e ON g.ex_code = e.ex_code
                                    JOIN  Exam_Course ec ON g.c_code = ec.c_code AND g.ex_code = ec.ex_code
                                    JOIN  Departments d ON ec.d_code = d.d_code
                                    WHERE s.st_id = @studentId
                                    ORDER BY e.ex_date DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@studentId", studentId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var examInfo = new StudentExamInfo
                        {
                            StudentName = reader["StudentName"]?.ToString() ?? "",
                            DepartmentName = reader["DepartmentName"]?.ToString() ?? "",
                            CourseName = reader["CourseName"]?.ToString() ?? "",
                            CourseCredit = reader.IsDBNull(reader.GetOrdinal("CourseCredit")) ? 0 : Convert.ToInt32(reader["CourseCredit"]),
                            ExamType = reader["ExamType"]?.ToString() ?? "",
                            ExamDate = !reader.IsDBNull(reader.GetOrdinal("ExamDate")) ? Convert.ToDateTime(reader["ExamDate"]).ToString("yyyy-MM-dd") : string.Empty,
                            Grade = reader.IsDBNull(reader.GetOrdinal("Grade")) ? 0 : Convert.ToDecimal(reader["Grade"])
                        };


                        list.Add(examInfo);
                    }
                }
            }

            return list;
        }
    }




}
