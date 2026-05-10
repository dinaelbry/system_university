using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace system_university
{
    public partial class StaffForm : Form
    {
        private DBHelper db = new DBHelper();
        private bool isRowSelected = false;

        public StaffForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // إضافة علامات الحfields الإجبارية
            label2.Text += " *";
            label3.Text += " *";
            label4.Text += " *";
            label6.Text += " *";
            label7.Text += " *";

            // تعطيل أزرار التعديل والحذف في البداية
            button2.Enabled = false;
            button3.Enabled = false;

            LoadDepartments();
            LoadPositions();
            GetNextStaffId();
        }

        private void LoadDepartments()
        {
            comboBox1.DataSource = db.LoadDepartments();
            comboBox1.DisplayMember = "DepartmentName";
            comboBox1.ValueMember = "Code";
            comboBox1.SelectedIndex = -1;
        }

        private void LoadPositions()
        {
            comboBox2.DataSource = db.LoadPositions();
            comboBox2.DisplayMember = "position_name";
            comboBox2.ValueMember = "stf_p_id";
            comboBox2.SelectedIndex = -1;
        }

        private DataGridView GetDataGridView1()
        {
            return dataGridView1;
        }

        private void LoadStaffData(DataGridView dataGridView1)
        {
            dataGridView1.DataSource = db.GetAllStaff();
            dataGridView1.Columns["d_code"].Visible = false;
            dataGridView1.Columns["stf_p_id"].Visible = false;
            if (dataGridView1.Columns.Contains("d_code"))
                dataGridView1.Columns["d_code"].Visible = false;

            if (dataGridView1.Columns.Contains("stf_p_id"))
                dataGridView1.Columns["stf_p_id"].Visible = false;

            AddRowNumbers();
        }

        private void AddRowNumbers()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void GetNextStaffId()
        {
            textBox1.Text = db.GetMaxId("Staff", "s_id").ToString();
        }

        private void ClearFormStaff()
        {
            GetNextStaffId();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            numericUpDown1.Value = 0;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
            isRowSelected = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private bool CheckIfDepartmentExists(int departmentId)
        {
            return db.CheckIfDepartmentExists(departmentId);
        }



        #region Event Handlers

        // دالة للتحقق من صحة المدخلات
        private bool ValidateInputs()
        {
            // التحقق من الحقول الإلزامية
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                comboBox1.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // التحقق من صحة الرقم في الحقل salary
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Salary must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        //add
        // تعديل الكود للتحقق من null قبل استخدام ToString()
        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            bool staffExists = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // تحقق من أن قيمة الخلية ليست null
                if (row.Cells["s_id"].Value != null && row.Cells["s_id"].Value.ToString() == textBox1.Text)
                {
                    staffExists = true;
                    break;
                }
            }

            if (!staffExists)
            {
                // إضافة الموظف بعد التحقق من المدخلات
                Staff stf = new Staff
                {
                    s_id = int.Parse(textBox1.Text),
                    s_name = textBox2.Text,
                    s_phone = textBox3.Text,
                    s_email = textBox4.Text,
                    s_salary = numericUpDown1.Value,
                    hire_date = dateTimePicker1.Value,
                    d_code = Convert.ToInt32(comboBox1.SelectedValue),
                    stf_p_id = Convert.ToInt32(comboBox2.SelectedValue)
                };
                if (!CheckIfDepartmentExists(stf.d_code))
                {
                    MessageBox.Show("The department does not exist.");
                    return;
                }

                db.AddStaff(stf);
                LoadStaffData(GetDataGridView1());
                ClearFormStaff();
                MessageBox.Show("Staff member added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This staff member already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        //update
        private void button2_Click(object sender, EventArgs e)
        {
            if (!isRowSelected)
            {
                MessageBox.Show("Please select a staff member to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // التحقق من المدخلات
            if (!ValidateInputs())
            {
                return;
            }

            Staff stf = new Staff
            {
                s_id = int.Parse(textBox1.Text),
                s_name = textBox2.Text,
                s_phone = textBox3.Text,
                s_email = textBox4.Text,
                s_salary = numericUpDown1.Value,
                hire_date = dateTimePicker1.Value,
                d_code = Convert.ToInt32(comboBox1.SelectedValue),
                stf_p_id = Convert.ToInt32(comboBox2.SelectedValue)
            };

            db.UpdateStaff(stf);
            LoadStaffData(GetDataGridView1());
            ClearFormStaff();
            MessageBox.Show("Staff member updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (!isRowSelected)
            {
                MessageBox.Show("Please select a staff member to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("No staff ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this staff member?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            db.DeleteStaff(int.Parse(textBox1.Text));
            LoadStaffData(GetDataGridView1());
            ClearFormStaff();
            MessageBox.Show("Staff member deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearFormStaff();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.SearchStaff(textBox5.Text.Trim());
            AddRowNumbers();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
                // تحميل البيانات فقط إذا كان التسجيل ناجحاً
                LoadStaffData(GetDataGridView1()); // أو LoadStaffData() في حالة StaffForm
           
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["s_id"]?.Value?.ToString();
            textBox2.Text = row.Cells["name"]?.Value?.ToString();
            textBox3.Text = row.Cells["phone"]?.Value?.ToString();
            textBox4.Text = row.Cells["email"]?.Value?.ToString();
            numericUpDown1.Value = row.Cells["salary"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["salary"].Value) : 0;

            if (DateTime.TryParse(row.Cells["hire_date"].Value?.ToString(), out DateTime hireDate))
                dateTimePicker1.Value = hireDate;
            else
                dateTimePicker1.Value = DateTime.Today;

            // تعيين قيمة ComboBox1
            comboBox1.SelectedIndex = comboBox1.FindStringExact(row.Cells["department"]?.Value?.ToString() ?? "");

            // تعيين قيمة ComboBox2
            comboBox2.SelectedIndex = comboBox2.FindStringExact(row.Cells["position"]?.Value?.ToString() ?? "");


            isRowSelected = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }


        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            ApplyButtonEffects(this);
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

        // Update the Button_MouseEnter and Button_MouseLeave signatures to match the EventHandler delegate
        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn != null)
                btn.BackColor = Color.LightBlue;
        }

        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn != null)
                btn.BackColor = SystemColors.Control;
        }

    }
}