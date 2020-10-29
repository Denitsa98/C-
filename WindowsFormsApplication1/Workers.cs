using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Workers : Form
    {
        public Workers()
        {
            InitializeComponent();
        }

        private void Workers_Load_1(object sender, EventArgs e)
        {
            DataSet dataSet = DBConnection.SelectAllPositions();

            //Попълване на комбобокса за позиция
            if (dataSet.Tables[0].Rows.Count >= 1)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Position.AddPositionToList(dataSet.Tables[0].Rows[i]["NamePos"].ToString());
                    comboBox.Items.Add(dataSet.Tables[0].Rows[i]["NamePos"].ToString());
                }
            }

            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }

            FillDepartmentComboBox();
        }


        private void FillDepartmentComboBox()
        {
            DataSet dataSet = DBConnection.SelectAllDepartments();

            if (dataSet.Tables[0].Rows.Count >= 1)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Department.AddDepartmentToList(new Department(dataSet.Tables[0].Rows[i]["Name"].ToString()));
                    comboBox2.Items.Add(dataSet.Tables[0].Rows[i]["Name"].ToString());
                }
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please enter a name/lastname!");
                return;
            }

            //int workerID;
            string name = textBox2.Text;
            string lastname = textBox3.Text;
            //string date = (textBox6.Text);
            DateTime date = DateTime.Parse(textBox6.Text);

            /*try
            {
                workerID = int.Parse(textBox1.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a ID!");

                return;
            }*/

            int idOfPos = DBConnection.GetIDByPositionName(comboBox.SelectedItem.ToString());

            //Изпълнение на метод, който изпраща заявка, която връща ID на избрания отдел
            int idOfDep = DBConnection.GetDepartmentID(comboBox2.SelectedItem.ToString());

            /*if (idOfDep == -1)
            {
                MessageBox.Show("There is no ID for type: " + typeListBox.SelectedItem.ToString() + "!");

                return;
            }*/
            DBConnection.InsertWorkerToDB(name, lastname, idOfPos, idOfDep, date);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = DBConnection.SelectAllWorkers();
            dataGridView1.DataSource= dt;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-3MKAK0L;Initial Catalog=CompanyDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            int idOfPos = DBConnection.GetIDByPositionName(comboBox.SelectedItem.ToString());

            //DateTime date = DateTime.Parse(textBox6.Text);
            //Изпълнение на метод, който изпраща заявка, която връща ID на избрания тип
            int idOfDep = DBConnection.GetDepartmentID(comboBox2.SelectedItem.ToString());
            SqlDataAdapter dataAdap = new SqlDataAdapter("UPDATE Worker SET Name= '" + textBox2.Text + "', Lastname ='" + textBox3.Text + "', PositionID ='" + idOfPos + "', DepartmentID ='" + idOfDep + "', АppointmentDate ='" + textBox6.Text + "'WHERE WorkerID='" + textBox1.Text + "'", conn);
            dataAdap.SelectCommand.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Data updated successfully!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please select the row, which you want to delete!");
                return;
            }

            //Изпраща се завката за изтриване
            if (!DBConnection.DeleteWorkerbyID(textBox1.Text))
            {
                MessageBox.Show("There is a problem with deleting this worker! Maybe this worker doesn't exist in the database! :(");
            }
            else
            {
                MessageBox.Show("The worker is deleted successfully!");
            }

            //Премахва се от листбокса и от комбото
            //depListB.Items.RemoveAt(delCombo.SelectedIndex);
            //delCombo.Items.RemoveAt(delCombo.SelectedIndex);
        }
    }
}
