namespace system_university
{
    partial class Form1
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
            buttonOpenStudent = new Button();
            buttonOpenStaff = new Button();
            SuspendLayout();
            // 
            // buttonOpenStudent
            // 
            buttonOpenStudent.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            buttonOpenStudent.Location = new Point(191, 87);
            buttonOpenStudent.Name = "buttonOpenStudent";
            buttonOpenStudent.Size = new Size(190, 80);
            buttonOpenStudent.TabIndex = 0;
            buttonOpenStudent.Text = "Student";
            buttonOpenStudent.UseVisualStyleBackColor = true;
            buttonOpenStudent.Click += buttonOpenStudent_Click;
            // 
            // buttonOpenStaff
            // 
            buttonOpenStaff.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            buttonOpenStaff.Location = new Point(191, 202);
            buttonOpenStaff.Name = "buttonOpenStaff";
            buttonOpenStaff.Size = new Size(190, 74);
            buttonOpenStaff.TabIndex = 1;
            buttonOpenStaff.Text = "Staff";
            buttonOpenStaff.UseVisualStyleBackColor = true;
            buttonOpenStaff.Click += buttonOpenStaff_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 377);
            Controls.Add(buttonOpenStaff);
            Controls.Add(buttonOpenStudent);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "University";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonOpenStudent;
        private Button buttonOpenStaff;
    }
}