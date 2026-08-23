using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();


            this.Font = new Font("Times New Roman", 14F, FontStyle.Regular);
            this.ForeColor = Color.Black;
            this.BackColor = Color.DarkGray;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None; 
            this.Padding = new Padding(2);  
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
