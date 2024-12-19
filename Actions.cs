using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolCloneDataFromGSHT
{
    public partial class Actions : Form
    {
        public Actions()
        {
            InitializeComponent();
        }

        private void Actions_Load(object sender, EventArgs e)
        {
            string cookieID = Properties.Settings.Default.cookieID;
            if (cookieID == null || cookieID.Length == 0)
            {
                MessageBox.Show("Chưa đăng nhập");
                LoginForm lg = new LoginForm();
                lg.ShowDialog();
                this.Close();
            }
        }
    }
}
