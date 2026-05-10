using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace system_university
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpenStudent_Click(object sender, EventArgs e)
        {
            StudentForm form = new StudentForm();
            form.ShowDialog();
        }

        private void buttonOpenStaff_Click(object sender, EventArgs e)
        {
            StaffForm form = new StaffForm();
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
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

                if (ctrl.HasChildren)
                {
                    ApplyButtonEffects(ctrl);
                }
            }
        }

        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn != null)
            {
                btn.BackColor = Color.LightSkyBlue;
                btn.Font = new Font(btn.Font.FontFamily,12, FontStyle.Bold);
            }
        }

        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn != null)
            {
                btn.BackColor = SystemColors.Control;
                btn.Font = new Font(btn.Font.FontFamily,10, FontStyle.Regular);
            }
        }
    }
}
