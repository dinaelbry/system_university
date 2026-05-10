using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail; 
using System.Data.SqlClient;


namespace system_university
{
    public partial class StudentForm : Form
    {
        private DBHelper db = new DBHelper();
        private bool isRowSelected = false;

        public StudentForm()
        {
            InitializeComponent();
            SetupForm();
            GetNextStudentId();
        }

        private void SetupForm()
        {
            label2.Text += " *";
            label3.Text += " *";
            label4.Text += " *";
            label5.Text += " *";

            // تعطيل أزرار التعديل والحذف في البداية
            button2.Enabled = false;
            button3.Enabled = false;

        }

        private void GetNextStudentId()
        {
            textBox1.Text = db.GetMaxId("Students", "st_id").ToString();
        }

        private void ClearForm()
        {
            GetNextStudentId();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton1.Checked = true;
            dateTimePicker1.Value = DateTime.Today;
            isRowSelected = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //
            try
            {
                var mail = new MailAddress(textBox4.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid email address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // التحقق من صحة رقم الهاتف (يجب أن يكون رقماً فقط)
            if (!long.TryParse(textBox3.Text, out _))
            {
                MessageBox.Show("Phone number must contain only digits.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //
            return true;
        }
        //loading data
        private void LoadData()
        {
            DataTable dt = db.GetAllStudents();

            if (!dt.Columns.Contains("Age"))
                dt.Columns.Add("Age", typeof(int));
            foreach (DataRow row in dt.Rows)
            {
                if (DateTime.TryParse(row["BirthDate"].ToString(), out DateTime birthdate))
                {
                    row["Age"] = CalculateAge( birthdate);
                }
            }


            dataGridView1.DataSource = dt;
            AddRowNumbers();
        }

        private void AddRowNumbers()
        {
            //if (dataGridView1.RowHeadersVisible == false)
            //    dataGridView1.RowHeadersVisible = true;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private int CalculateAge(DateTime st_birth_of_date)
        {
            int age = DateTime.Today.Year - st_birth_of_date.Year;
            if (st_birth_of_date > DateTime.Today.AddYears(-age)) age--;
            return age;
        }

        #region Event Handlers

        //add
        private void button1_Click(object sender, EventArgs e)
        {

            if (!ValidateInputs()) return;
            // التحقق مما إذا كان الطالب موجودًا بالفعل في الداتا جريد
            bool studentExists = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["st_id"] != null && row.Cells["st_id"].Value != null &&
                    row.Cells["st_id"].Value.ToString() == textBox1.Text)
                {
                    studentExists = true;
                    break;
                }
            }


            if (studentExists)
            {
                MessageBox.Show("This student already exists.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Student s = new Student
            {
                Id = int.Parse(textBox1.Text),
                Name = textBox2.Text,
                Gender = radioButton1.Checked,
                Address = textBox5.Text,
                Phone = textBox3.Text,
                Email = textBox4.Text,
                Birthdate = dateTimePicker1.Value
            };

            db.AddStudent(s);
            LoadData();
            ClearForm();
            MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //update
        private void button2_Click(object sender, EventArgs e)
        {
            if (!isRowSelected)
            {
                MessageBox.Show("Please select a student to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            Student s = new Student
            {
                Id = int.Parse(textBox1.Text),
                Name = textBox2.Text,
                Gender = radioButton1.Checked,
                Address = textBox5.Text,
                Phone = textBox3.Text,
                Email = textBox4.Text,
                Birthdate = dateTimePicker1.Value
            };

            db.UpdateStudent(s);
            LoadData();
            ClearForm();
            MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //delete

        private void button3_Click(object sender, EventArgs e)
        {
            if (!isRowSelected)
            {
                MessageBox.Show("Please select a student to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            db.DeleteStudent(int.Parse(textBox1.Text));

            MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearForm();
        }

        //new
        private void button4_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        //search
        private void button5_Click(object sender, EventArgs e)
        {
            // التحقق من أن حقل البحث غير فارغ
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("please enter ID or student name", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // تنفيذ البحث
            DataTable dt = db.SearchStudent(textBox6.Text.Trim());

            // التحقق من وجود نتائج
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("no result", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // إضافة عمود العمر إذا لم يكن موجوداً
            if (!dt.Columns.Contains("Age"))
                dt.Columns.Add("Age", typeof(int));

            // حساب العمر لكل طالب
            foreach (DataRow row in dt.Rows)
            {
                if (DateTime.TryParse(row["BirthDate"].ToString(), out DateTime birthdate))
                {
                    row["Age"] = CalculateAge(birthdate);
                }
            }



            // عرض النتائج
            dataGridView1.DataSource = dt;
            AddRowNumbers();
        }



        //show all

        private void button6_Click(object sender, EventArgs e)
        {

            // تحميل البيانات فقط إذا كان التسجيل ناجحاً
            LoadData();

        }

        //btnShowDetails
        private void btnShowDetails_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Cells["st_id"].Value == null)
            {
                MessageBox.Show("Please choose student first");
                return;
            }

            int selectedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["st_id"].Value);
            StudentDetailsForm detailsForm = new StudentDetailsForm(selectedId);
            detailsForm.ShowDialog();


        }

        #endregion

        private void StudentForm_Load(object sender, EventArgs e)
        {
            ApplyButtonEffects(this);
            LoadDepartments();
            LoadCourses();
        }
        private void ApplyButtonEffects(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.MouseEnter += Button_MouseEnter;
                    btn.MouseLeave += Button_MouseLeave;
                }
                else if (ctrl.HasChildren)
                {
                    ApplyButtonEffects(ctrl);
                }
            }
        }

        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn != null)
            {
                btn.BackColor = Color.LightCoral;
            }
        }

        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn != null)
            {
                btn.BackColor = SystemColors.Control;
            }
        }



        private void LoadDepartments()
        {
            string query = "SELECT d_code AS Code, d_name AS DepartmentName FROM Departments";
            DataTable dt = DBHelper.GetData(query);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "DepartmentName";
            comboBox1.ValueMember = "Code";
            comboBox1.SelectedIndex = -1;
        }

        private void LoadCourses()
        {
            string query = "SELECT c_code AS Code, c_name AS CourseName FROM Courses";
            DataTable dt = DBHelper.GetData(query);

            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "CourseName";
            comboBox2.ValueMember = "Code";
            comboBox2.SelectedIndex = -1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                string? selectedDepartment = comboBox1.SelectedValue?.ToString();
                if (!string.IsNullOrEmpty(selectedDepartment))
                {
                    ShowStudentsByDepartment(selectedDepartment);
                }
            }
            else
            {
                MessageBox.Show("Please select a department.");
            }
        }

        private void ShowStudentsByDepartment(string departmentCode)
        {
            string query = @"
                                SELECT DISTINCT 
                                    s.st_id, 
                                    s.st_name AS Name, 
                                    s.st_phone AS Phone, 
                                    s.st_email AS Email, 
                                    s.st_address AS Address,
                                    CASE WHEN s.st_gender = 1 THEN 'Male' ELSE 'Female' END AS Gender,
                                    s.st_birth_of_date AS BirthDate
                                FROM Students s
                                LEFT JOIN Grades g ON g.st_id = s.st_id
                                LEFT JOIN Exams ex ON ex.ex_code = g.ex_code
                                LEFT JOIN Exam_Course ec ON ec.ex_code = ex.ex_code
                                INNER JOIN Departments d ON ec.d_code = d.d_code
                                WHERE d.d_code = @departmentCode";

            using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@departmentCode", departmentCode);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                // إضافة عمود العمر
                if (!dt.Columns.Contains("Age"))
                    dt.Columns.Add("Age", typeof(int));

                // تعديل قيمة Gender وعمر كل طالب
                foreach (DataRow row in dt.Rows)
                {
                    if (DateTime.TryParse(row["BirthDate"].ToString(), out DateTime birthdate))
                    {
                        row["Age"] = CalculateAge(birthdate);
                    }
                }


                dataGridView1.DataSource = dt;
                AddRowNumbers();
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                string? selectedCourse = comboBox2.SelectedValue?.ToString();
                if (!string.IsNullOrEmpty(selectedCourse))
                {
                    CountStudentsInCourse(selectedCourse);
                }
            }
            else
            {
                MessageBox.Show("Please select a course.");
            }
        }

        private void CountStudentsInCourse(string courseCode)
        {
            string query = @"SELECT COUNT(DISTINCT st_id)
                            FROM Registration r 
                            INNER JOIN Course_Term ct ON r.course_term_id = ct.course_term_id 
                            WHERE r.c_code = @courseCode
                            ";



            using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@courseCode", courseCode);
                conn.Open();
                object result = cmd.ExecuteScalar();
                MessageBox.Show("Number of students enrolled in course: " + result?.ToString());
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["st_id"]?.Value?.ToString() ?? "";
            textBox2.Text = row.Cells["Name"]?.Value?.ToString() ?? "";
            textBox3.Text = row.Cells["Phone"]?.Value?.ToString() ?? "";
            textBox4.Text = row.Cells["Email"]?.Value?.ToString() ?? "";
            textBox5.Text = row.Cells["Address"]?.Value?.ToString() ?? "";
            if (row.Cells["BirthDate"] != null && DateTime.TryParse(row.Cells["BirthDate"].Value?.ToString(), out DateTime birthdate))
                dateTimePicker1.Value = birthdate;
            else
                dateTimePicker1.Value = DateTime.Today;
            string gender = row.Cells["Gender"].Value?.ToString() ?? "";
            radioButton1.Checked = gender == "Male";
            radioButton2.Checked = gender == "Female";


            isRowSelected = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }
    }
}
