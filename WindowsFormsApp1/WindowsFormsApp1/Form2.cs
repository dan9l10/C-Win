using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            progressBar1.Show();
            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Maximum = 99;
            progressBar1.Value = 1;
            progressBar1.Step = 1;
            for (int i = 0; i < 99; i = +33)
            {
                progressBar1.Value = +i;
            }
        }
    }
}
