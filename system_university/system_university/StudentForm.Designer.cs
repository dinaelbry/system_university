

namespace system_university
{
    partial class StudentForm
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

        private string GetText()
        {
            return Text;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label7 = new Label();
            label6 = new Label();
            dateTimePicker1 = new DateTimePicker();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button5 = new Button();
            textBox6 = new TextBox();
            button6 = new Button();
            dBHelperBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            btnShowDetails = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button7 = new Button();
            button8 = new Button();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            st_id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            phone = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            BirthDate = new DataGridViewTextBoxColumn();
            Age = new DataGridViewTextBoxColumn();
            gender = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dBHelperBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(47, 277);
            label7.Name = "label7";
            label7.Size = new Size(56, 20);
            label7.TabIndex = 39;
            label7.Text = "gender";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(47, 227);
            label6.Name = "label6";
            label6.Size = new Size(92, 20);
            label6.TabIndex = 38;
            label6.Text = "date of birth";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(145, 222);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 37;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button4.Location = new Point(752, 119);
            button4.Name = "button4";
            button4.Size = new Size(120, 35);
            button4.TabIndex = 35;
            button4.Text = "NEW";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.Location = new Point(611, 119);
            button3.Name = "button3";
            button3.Size = new Size(120, 35);
            button3.TabIndex = 34;
            button3.Text = "DELETE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.Location = new Point(752, 66);
            button2.Name = "button2";
            button2.Size = new Size(120, 35);
            button2.TabIndex = 33;
            button2.Text = "UPDATE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Location = new Point(611, 66);
            button1.Name = "button1";
            button1.Size = new Size(120, 35);
            button1.TabIndex = 32;
            button1.Text = "ADD";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(113, 324);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(304, 207);
            textBox5.TabIndex = 31;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(145, 171);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 30;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(145, 134);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 29;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(145, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 28;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(145, 42);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 27;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(246, 277);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(76, 24);
            radioButton2.TabIndex = 26;
            radioButton2.TabStop = true;
            radioButton2.Text = "female";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(145, 277);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(63, 24);
            radioButton1.TabIndex = 25;
            radioButton1.TabStop = true;
            radioButton1.Text = "male";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 334);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 24;
            label5.Text = "address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 171);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 23;
            label4.Text = "email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 134);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 22;
            label3.Text = "phone";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 85);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 21;
            label2.Text = "name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 44);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 20;
            label1.Text = "student ID";
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(1193, 74);
            button5.Name = "button5";
            button5.Size = new Size(67, 27);
            button5.TabIndex = 40;
            button5.Text = "Search";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(1027, 74);
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "enter name or id";
            textBox6.Size = new Size(151, 27);
            textBox6.TabIndex = 41;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(767, 196);
            button6.Name = "button6";
            button6.Size = new Size(221, 47);
            button6.TabIndex = 42;
            button6.Text = "Show All Student";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // dBHelperBindingSource
            // 
            dBHelperBindingSource.DataSource = typeof(DBHelper);
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { st_id, name, phone, email, address, BirthDate, Age, gender });
            dataGridView1.Location = new Point(488, 277);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1056, 327);
            dataGridView1.TabIndex = 43;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnShowDetails
            // 
            btnShowDetails.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnShowDetails.Location = new Point(488, 196);
            btnShowDetails.Name = "btnShowDetails";
            btnShowDetails.Size = new Size(219, 47);
            btnShowDetails.TabIndex = 44;
            btnShowDetails.Text = "Show Details";
            btnShowDetails.UseVisualStyleBackColor = true;
            btnShowDetails.Click += btnShowDetails_Click;
            // 
            // comboBox1
            // 
            comboBox1.DisplayMember = "DepartmentName";
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1027, 209);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 45;
            comboBox1.ValueMember = "DepartmentName";
            // 
            // comboBox2
            // 
            comboBox2.DisplayMember = "CourseName";
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(1302, 210);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 46;
            comboBox2.ValueMember = "CourseName";
            // 
            // button7
            // 
            button7.Location = new Point(1194, 208);
            button7.Name = "button7";
            button7.Size = new Size(63, 29);
            button7.TabIndex = 47;
            button7.Text = "search";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(1471, 207);
            button8.Name = "button8";
            button8.Size = new Size(73, 30);
            button8.TabIndex = 48;
            button8.Text = "count";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1030, 42);
            label9.Name = "label9";
            label9.Size = new Size(104, 20);
            label9.TabIndex = 50;
            label9.Text = "search student";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1300, 177);
            label10.Name = "label10";
            label10.Size = new Size(103, 20);
            label10.TabIndex = 51;
            label10.Text = "choose course";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1027, 177);
            label11.Name = "label11";
            label11.Size = new Size(138, 20);
            label11.TabIndex = 52;
            label11.Text = "choose department";
            // 
            // st_id
            // 
            st_id.DataPropertyName = "st_id";
            st_id.HeaderText = "ID";
            st_id.MinimumWidth = 6;
            st_id.Name = "st_id";
            st_id.Width = 125;
            // 
            // name
            // 
            name.DataPropertyName = "name";
            name.HeaderText = "name";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.Width = 125;
            // 
            // phone
            // 
            phone.DataPropertyName = "phone";
            phone.HeaderText = "phone";
            phone.MinimumWidth = 6;
            phone.Name = "phone";
            phone.Width = 125;
            // 
            // email
            // 
            email.DataPropertyName = "email";
            email.HeaderText = "email";
            email.MinimumWidth = 6;
            email.Name = "email";
            email.Width = 125;
            // 
            // address
            // 
            address.DataPropertyName = "address";
            address.HeaderText = "address";
            address.MinimumWidth = 6;
            address.Name = "address";
            address.Width = 125;
            // 
            // BirthDate
            // 
            BirthDate.DataPropertyName = "BirthDate";
            BirthDate.HeaderText = "birth date";
            BirthDate.MinimumWidth = 6;
            BirthDate.Name = "BirthDate";
            BirthDate.Width = 125;
            // 
            // Age
            // 
            Age.DataPropertyName = "Age";
            Age.HeaderText = "Age";
            Age.MinimumWidth = 6;
            Age.Name = "Age";
            Age.Width = 125;
            // 
            // gender
            // 
            gender.DataPropertyName = "Gender";
            gender.HeaderText = "gender";
            gender.MinimumWidth = 6;
            gender.Name = "gender";
            gender.Width = 125;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1599, 631);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(btnShowDetails);
            Controls.Add(dataGridView1);
            Controls.Add(button6);
            Controls.Add(textBox6);
            Controls.Add(button5);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dateTimePicker1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "StudentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "student form";
            Load += StudentForm_Load;
            ((System.ComponentModel.ISupportInitialize)dBHelperBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        private void Button5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion



        private Label label7;
        private Label label6;
        private DateTimePicker dateTimePicker1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button5;
        private TextBox textBox6;
        private Button button6;
        private BindingSource dBHelperBindingSource;
        private DataGridView dataGridView1;
        private Button btnShowDetails;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button7;
        private Button button8;
        private Label label9;
        private Label label10;
        private Label label11;
        private DataGridViewTextBoxColumn st_id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn phone;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn address;
        private DataGridViewTextBoxColumn BirthDate;
        private DataGridViewTextBoxColumn Age;
        private DataGridViewTextBoxColumn gender;
    }
}