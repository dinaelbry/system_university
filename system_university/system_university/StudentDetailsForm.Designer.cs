namespace system_university
{
    partial class StudentDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StudentName = new Label();
            Department = new Label();
            GPA = new Label();
            dataGridView1 = new DataGridView();
            DepartmentName = new DataGridViewTextBoxColumn();
            CourseName = new DataGridViewTextBoxColumn();
            CourseCredit = new DataGridViewTextBoxColumn();
            ExamType = new DataGridViewTextBoxColumn();
            ExamDate = new DataGridViewTextBoxColumn();
            Grade = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // StudentName
            // 
            StudentName.AutoSize = true;
            StudentName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            StudentName.Location = new Point(164, 23);
            StudentName.Name = "StudentName";
            StudentName.Size = new Size(161, 31);
            StudentName.TabIndex = 0;
            StudentName.Text = "student name";
            // 
            // Department
            // 
            Department.AutoSize = true;
            Department.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            Department.Location = new Point(164, 69);
            Department.Name = "Department";
            Department.Size = new Size(141, 31);
            Department.TabIndex = 1;
            Department.Text = "department";
            // 
            // GPA
            // 
            GPA.AutoSize = true;
            GPA.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            GPA.Location = new Point(164, 119);
            GPA.Name = "GPA";
            GPA.Size = new Size(59, 31);
            GPA.TabIndex = 2;
            GPA.Text = "GPA";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { DepartmentName, CourseName, CourseCredit, ExamType, ExamDate, Grade });
            dataGridView1.Location = new Point(164, 178);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(803, 328);
            dataGridView1.TabIndex = 3;
            // 
            // DepartmentName
            // 
            DepartmentName.DataPropertyName = "DepartmentName";
            DepartmentName.HeaderText = "Department";
            DepartmentName.MinimumWidth = 6;
            DepartmentName.Name = "DepartmentName";
            DepartmentName.ReadOnly = true;
            DepartmentName.Width = 125;
            // 
            // CourseName
            // 
            CourseName.DataPropertyName = "CourseName";
            CourseName.HeaderText = "Course";
            CourseName.MinimumWidth = 6;
            CourseName.Name = "CourseName";
            CourseName.ReadOnly = true;
            CourseName.Width = 125;
            // 
            // CourseCredit
            // 
            CourseCredit.DataPropertyName = "CourseCredit";
            CourseCredit.HeaderText = "Hours";
            CourseCredit.MinimumWidth = 6;
            CourseCredit.Name = "CourseCredit";
            CourseCredit.ReadOnly = true;
            CourseCredit.Width = 125;
            // 
            // ExamType
            // 
            ExamType.DataPropertyName = "ExamType";
            ExamType.HeaderText = "Exam Type";
            ExamType.MinimumWidth = 6;
            ExamType.Name = "ExamType";
            ExamType.ReadOnly = true;
            ExamType.Width = 125;
            // 
            // ExamDate
            // 
            ExamDate.DataPropertyName = "ExamDate";
            ExamDate.HeaderText = "Exam Date";
            ExamDate.MinimumWidth = 6;
            ExamDate.Name = "ExamDate";
            ExamDate.ReadOnly = true;
            ExamDate.Width = 125;
            // 
            // Grade
            // 
            Grade.DataPropertyName = "Grade";
            Grade.HeaderText = "Grade";
            Grade.MinimumWidth = 6;
            Grade.Name = "Grade";
            Grade.ReadOnly = true;
            Grade.Width = 125;
            // 
            // StudentDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 518);
            Controls.Add(dataGridView1);
            Controls.Add(GPA);
            Controls.Add(Department);
            Controls.Add(StudentName);
            Name = "StudentDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentDetailsForm";
            Load += StudentDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label StudentName;
        private Label Department;
        private Label GPA;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn DepartmentName;
        private DataGridViewTextBoxColumn CourseName;
        private DataGridViewTextBoxColumn CourseCredit;
        private DataGridViewTextBoxColumn ExamType;
        private DataGridViewTextBoxColumn ExamDate;
        private DataGridViewTextBoxColumn Grade;
    }
}