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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            DataTable dt = DBConnection.SelectAllWorkers();
            dataGridView1.DataSource = dt;
            DataSet dataSet = DBConnection.SelectAllPositions();

            //Попълване на комбобокса за позиция
            if (dataSet.Tables[0].Rows.Count >= 1)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Position.AddPositionToList(dataSet.Tables[0].Rows[i]["NamePos"].ToString());
                    schPosition.Items.Add(dataSet.Tables[0].Rows[i]["NamePos"].ToString());
                }
            }
            FillDepartmentComboBox();
            FillLanguageComboBox();
            FillwIDComboBox();
        }

        private void FillDepartmentComboBox()
        {
            DataSet dataSet = DBConnection.SelectAllDepartments();

            if (dataSet.Tables[0].Rows.Count >= 1)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Department.AddDepartmentToList(new Department(dataSet.Tables[0].Rows[i]["Name"].ToString()));
                    schDepartment.Items.Add(dataSet.Tables[0].Rows[i]["Name"].ToString());
                }
            }
        }

        private void FillLanguageComboBox()
        {
            DataSet dataSet = DBConnection.SelectAllLanguage();

            if (dataSet.Tables[0].Rows.Count >= 1)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Language.AddLanguageToList(new Language(dataSet.Tables[0].Rows[i]["Name"].ToString()));
                    schLang.Items.Add(dataSet.Tables[0].Rows[i]["Name"].ToString());
                }
            }
        }

        private void FillwIDComboBox()
        {
            DataSet dataSet = DBConnection.SelectAllWorkerName();

            if (dataSet.Tables[0].Rows.Count >= 1)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Worker.AddIDToList(new Worker(dataSet.Tables[0].Rows[i]["Name"].ToString()));
                    schw.Items.Add(dataSet.Tables[0].Rows[i]["Name"].ToString());
                }
            }
        }

        private void schBox_TextChange(object sender, EventArgs e)
        {
            string lastname = schLnameBox.Text;

            DataTable dt = DBConnection.SelectWorkersByLastname(lastname);
            dataGridView1.DataSource = dt;
        }

        private void schPosition_changee(object sender, EventArgs e)
        {
            //string position = schPositionBox.Text;
            int idOfPos = DBConnection.GetIDByPositionName(schPosition.SelectedItem.ToString());

            DataTable dt = DBConnection.SelectWorkersByPos(idOfPos);
            dataGridView1.DataSource = dt;
        }

        private void schDepartment_changee(object sender, EventArgs e)
        {
            int idOfDep = DBConnection.GetDepartmentID(schDepartment.Text);

            DataTable dt = DBConnection.SelectWorkersByDep(idOfDep);
            dataGridView1.DataSource = dt;
        }
        
        private void schLang_changee(object sender, EventArgs e)
        {
            int idOfLanguages = DBConnection.GetLanguagesID(schLang.Text);

            DataTable dt = DBConnection.SelectWorkersByLanguages(idOfLanguages);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = DBConnection.SelectFiveLastWorkers();
            dataGridView1.DataSource = dt;
        }

        private void schIDw_change(object sender, EventArgs e)
        {
            string w = schw.Text;
            //string a = "Ivan";
            DataTable dt = DBConnection.SelectAbsence(w);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DateTime date=DateTime.Parse(textBox.Text);
            DataTable dt = DBConnection.SelectForPeriodWorkers();
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = DBConnection.SelectForPeriod2Workers();
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = DBConnection.SelectForPeriod3Workers();
            dataGridView1.DataSource = dt;
        }
    }
}
