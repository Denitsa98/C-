using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void insertupdatedeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Workers w=new Workers();
            w.Show();
        }

        private void updateDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpDepartment u = new UpDepartment();
            u.Show();
        }

        private void positionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpPosition p = new UpPosition();
            p.Show();
        }

        private void searchAndReferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search sch = new Search();
            sch.Show();
        }

        
    }
}
