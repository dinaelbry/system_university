using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace system_university
{
    public partial class StudentDetailsForm : Form
    {
        private readonly int studentId;
        private readonly DBHelper db = new DBHelper();

        public StudentDetailsForm(int st_id)
        {
            InitializeComponent();
            studentId = st_id;
        }

        private void StudentDetailsForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadStudentExamDetails();
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            AddColumn("DepartmentName", "Department", 150);
            AddColumn("CourseName", "Course", 200);
            AddColumn("CourseCredit", "Hours", 80);
            AddColumn("ExamType", "Exam Type", 120);
            AddColumn("ExamDate", "Exam Date ", 120);
            AddColumn("Grade", "Grade", 80);

            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
        }

        private void AddColumn(string propertyName, string headerText, int width)
        {
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = propertyName,
                HeaderText = headerText,
                Width = width,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
        }

        private void LoadStudentExamDetails()
        {
            try
            {
                dataGridView1.DataSource = null;

                var examData = db.GetStudentExamInfo(studentId);

                if (examData.Count == 0)
                {
                    MessageBox.Show("There are no exam records for this student.");
                    GPA.Text = "Cumulative GPA: Not available.";
                    return;
                }

                var student = examData[0];
                StudentName.Text = $"Name: {student.StudentName}";
                Department.Text = $"Department: {student.DepartmentName}";

                dataGridView1.DataSource = new BindingList<StudentExamInfo>(examData);

                CalculateGPA(examData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading details: " + ex.Message);
            }
        }

        private void CalculateGPA(List<StudentExamInfo> examData)
        {
            decimal totalPoints = 0;
            int totalCredits = 0;

            foreach (var item in examData)
            {
                decimal point = ConvertGradeToPoints(item.Grade);
                totalPoints += point * item.CourseCredit;
                totalCredits += item.CourseCredit;
            }

            decimal gpa = totalCredits > 0 ? totalPoints / totalCredits : 0;
            GPA.Text = $"GPA: {Math.Round(gpa, 2)} (Total hours: {totalCredits})";
        }

        private decimal ConvertGradeToPoints(decimal grade)
        {
            return grade switch
            {
                >= 90 => 4.0m,
                >= 85 => 3.7m,
                >= 80 => 3.3m,
                >= 75 => 3.0m,
                >= 70 => 2.7m,
                >= 65 => 2.3m,
                >= 60 => 2.0m,
                >= 50 => 1.0m,
                _ => 0.0m
            };
        }

  
    }
}
