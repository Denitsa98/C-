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
    public partial class UpDepartment : Form
    {
        public UpDepartment()
        {
            InitializeComponent();
        }

        private void UpDepartment_Load(object sender, EventArgs e)
        {
            FillDepListBox();
            FillDepCombo();
        }

        //Метод, който попълва дропбокса с типове бельо
        private void FillDepListBox()
        {
            DataSet dataSet = DBConnection.SelectAllDepartments();

            if (dataSet.Tables[0].Rows.Count >= 1)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Department.AddDepartmentToList(new Department(dataSet.Tables[0].Rows[i]["Name"].ToString()));
                    depListB.Items.Add(dataSet.Tables[0].Rows[i]["Name"].ToString());
                }
            }
        }

        private void FillDepCombo()
        {
            DataSet dataSet = DBConnection.SelectAllDepartments();

            if (dataSet.Tables[0].Rows.Count >= 1)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Department.AddDepartmentToList(new Department(dataSet.Tables[0].Rows[i]["Name"].ToString()));
                    delCombo.Items.Add(dataSet.Tables[0].Rows[i]["Name"].ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (newtextBox.Text == "")
            {
                MessageBox.Show("Plase input the new name!");

                return;
            }
            //Ако изпълнението на метода за изпращане на заявка UPDATE върне false
            //то означава че съществува вече
            if (!DBConnection.UpdateDepByName(newtextBox.Text, depListB.SelectedItem.ToString()))
            {
                MessageBox.Show("There was a problem with the update! Maybe that department doesn't exist in the DB.");

                return;
            }
            else
            {
                //Ако върне true добавяме дадения тип към ListBox-a вместо да го чистим и наново
                //да изпращаме заявка към базата данни за да вземем всички типове наново плюс новодобавения
                MessageBox.Show("Department is updated successfully!");
                depListB.Items[depListB.Items.IndexOf(depListB.SelectedItem)] = newtextBox.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inputtextBox.Text == "")
            {
                MessageBox.Show("Plase input a department!");

                return;
            }

            if (Department.GetDepartmentList().Any(department => department.GetDepartment() == inputtextBox.Text))
            {
                MessageBox.Show("Sorry, but that department already exists! :(");

                return;
            }

            //Изиква метод, който изпраща SQL завката към базата и връща true или 
            if (!DBConnection.InsertDepartment(inputtextBox.Text))
            {
                MessageBox.Show("There was and error with inserting!");
                return;
            }

            MessageBox.Show("Successfully added a new department in the company!");

            //Добавяне на отдела към listBox-а, за да не се изпълнява наново INSERT заявка
            depListB.Items.Add(inputtextBox.Text);
            delCombo.Items.Add(inputtextBox.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (delCombo.SelectedItem == null)
            {
                MessageBox.Show("Please select a department.");
                return;
            }

            //Изпраща се завката за изтриване
            if (!DBConnection.DeleteDepByName(delCombo.SelectedItem.ToString()))
            {
                MessageBox.Show("There is a problem with deleting that department! Maybe that department doesn't exist in the database. :(");
            }
            else
            {
                MessageBox.Show("The department is deleted successfully!");
            }

            //Премахва се от листбокса и от комбото
            depListB.Items.RemoveAt(delCombo.SelectedIndex);
            delCombo.Items.RemoveAt(delCombo.SelectedIndex);
        }
    }
}
