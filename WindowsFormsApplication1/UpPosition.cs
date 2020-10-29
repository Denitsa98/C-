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

namespace WindowsFormsApplication1
{
    public partial class UpPosition : Form
    {
        public UpPosition()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpPosition_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataTable dt = DBConnection.SelectPosSal();

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-3MKAK0L;Initial Catalog=CompanyDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            SqlDataAdapter dataAdap = new SqlDataAdapter("UPDATE Position SET NamePos= '" + posBox.Text + "', Salary ='" + salaryBox.Text + "'WHERE PositionID='" + idBox.Text + "'", conn);
            dataAdap.SelectCommand.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Data updated successfully!");
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idBox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            posBox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            salaryBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idBox.Text == "")
            {
                MessageBox.Show("Please select the row, which you wannt to delete!");
                return;
            }
            
            //string pos = posBox.Text;
            //Изпраща се завката за изтриване
            if (!DBConnection.DeletePosByName(posBox.Text))
            {
                MessageBox.Show("There is a problem with deleting this position! Maybe this position doesn't exist in the database. :(");
            }
            else
            {
                MessageBox.Show("The position is deleted successfully!");
            } 


            //Премахва се от листбокса и от комбото
            //delCombo.Items.RemoveAt(delCombo.SelectedIndex);
            //dataGridView1.SelectedRows.delete
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fill();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (posBox.Text == "" || salaryBox.Text == "")
            {
                MessageBox.Show("Please enter a name of position and salary!");
                return;
            }

            if (Position.GetPositionList().Any(position => position.GetPosition() == posBox.Text))
            {
                MessageBox.Show("Sorry, but this position already exists! :(");
                return;
            }

            string nameP = posBox.Text;
            float salary = float.Parse(salaryBox.Text);

            if (!DBConnection.InsertPosition(nameP, salary))
            {
                MessageBox.Show("There was and error with inserting!");
            }
            else
            { 
                MessageBox.Show("Insert successfuly"); 
            }
        }
    }
 }
