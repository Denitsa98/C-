using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
//using WindowsFormsApplication1.Resources;

namespace WindowsFormsApplication1
{
    class DBConnection
    {
        private static string connetionString = "Data Source=DESKTOP-3MKAK0L;Initial Catalog=CompanyDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static SqlConnection conn;

        public static void ConnectToDB()
        {
            //Инициализиране на променливата за конекция
            conn = new SqlConnection(connetionString);
        }

        //Метод за въвеждане на работник
        public static void InsertWorkerToDB(string name, string lastname, int positionID, int departmentID, DateTime date)
        {
            ConnectToDB();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Worker(Name, Lastname, PositionID, DepartmentID, АppointmentDate) VALUES (@Name, @Lastname, @PositionID, @DepartmentID, @АppointmentDate)", conn);
            //Задаване на име на параметрите и стойност за тях
            //sqlCommand.Parameters.AddWithValue("@WorkerID", id);
            sqlCommand.Parameters.AddWithValue("@Name", name);
            sqlCommand.Parameters.AddWithValue("@Lastname", lastname);
            sqlCommand.Parameters.AddWithValue("@PositionID", positionID);
            sqlCommand.Parameters.AddWithValue("@DepartmentID", departmentID);
            sqlCommand.Parameters.AddWithValue("@АppointmentDate", date);

            conn.Open();
            sqlCommand.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Insert successful");
        }

        //Метод за връщане на всички съществуващи oтдели от базата данни
        public static DataSet SelectAllDepartments()
        {
            ConnectToDB();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT * FROM Department", conn));
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static DataTable SelectAllWorkers()
        {
            ConnectToDB();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT * FROM Worker", conn));
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            return dt;
        }

        public static DataSet SelectAllLanguage()
        {
            ConnectToDB();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT * FROM Languages", conn));
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static DataTable SelectPosSal()
        {
            ConnectToDB();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT * FROM Position", conn));
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            return dt; 
        }


        public static DataSet SelectAllWorkerName()
        {
            ConnectToDB();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT Name FROM Worker", conn));
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

        public static DataSet SelectAllPositions()
        {
            //Метод за отваряне на връзка към базата
            ConnectToDB();
            //Създаване на заявката
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT * FROM Position", conn));
            DataSet dataSet = new DataSet();

            //Попълване на променливата с върнатите данни
            dataAdapter.Fill(dataSet);

            return dataSet;
        }

        public static DataTable SelectWorkersByLastname(string lname)
        {
            ConnectToDB();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Worker WHERE Lastname LIKE'"+lname+"%'", conn);
            SqlDataAdapter dataAdapter= new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            return dt;
            //dataAdap.SelectCommand.ExecuteNonQuery();
            //conn.Close();
            //return dataSet;
        }

        public static DataTable SelectWorkersByPos(int pos)
        {
            ConnectToDB();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Worker WHERE PositionID LIKE'"+pos+"%'", conn);
            SqlDataAdapter dataAdapter= new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }

        public static DataTable SelectWorkersByDep(int dep)
        {
            ConnectToDB();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Worker WHERE DepartmentID LIKE'"+dep+"%'", conn);
            SqlDataAdapter dataAdapter= new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            return dt;
        }

        public static DataTable SelectWorkersByLanguages(int lng)
        {
            ConnectToDB();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT LanguageID, Name, Lastname, NamePos FROM Worker_languages, Worker, Position  WHERE Worker_languages.WorkerID = Worker.WorkerID AND Position.PositionID=Worker.PositionID AND LanguageID LIKE'" + lng + "%'", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            return dt;
        }

        public static DataTable SelectFiveLastWorkers()
        {
            ConnectToDB();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT TOP 5 Name, Lastname, АppointmentDate, NamePos FROM Worker, Position WHERE Position.PositionID=Worker.PositionID ORDER BY Worker.АppointmentDate DESC ", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }

        public static DataTable SelectForPeriodWorkers()
        {
            ConnectToDB();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT WorkerID, Name, Lastname, АppointmentDate, Position.NamePos FROM Worker,Position  WHERE Position.PositionID=Worker.PositionID AND АppointmentDate BETWEEN  '2019-01-01' AND '2020-01-01'", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            // WHERE АppointmentDate='2019-06-17' - raboti
            // WHERE АppointmentDate LIKE'" + date + "%'" - RABOTI
            //BETWEEN  #2013-01-01# AND  #2017-01-01#;"
            return dt;
        }

        public static DataTable SelectForPeriod2Workers()
        {
            ConnectToDB();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT WorkerID, Name, Lastname, АppointmentDate, Position.NamePos FROM Worker,Position WHERE Position.PositionID=Worker.PositionID AND АppointmentDate BETWEEN  '2018-01-01' AND '2019-01-01'", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }

        public static DataTable SelectForPeriod3Workers()
        {
            ConnectToDB();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT WorkerID, Name, Lastname, АppointmentDate, Position.NamePos FROM Worker,Position WHERE Position.PositionID=Worker.PositionID AND АppointmentDate BETWEEN  '2017-01-01' AND '2018-01-01'", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }
        
        public static DataTable SelectAbsence(string wname)
        {
            ConnectToDB();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT SUM(AbsenceSickness + AbsenceVacantion), Name from Report, Worker WHERE Worker.WorkerID=Report.WorkerID AND Name LIKE'" + wname + "%' group by Worker.Name;", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            // WHERE Report.MonthID BETWEEN '&MonthID' AND '&MonthID' 
            return dt;
        }

        ////Метод за връщане на ID на отдел
        public static int GetIDByPositionName(string position)
        {
            ConnectToDB();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT PositionID FROM Position WHERE NamePos = \'" + position + "\'", conn));
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count == 0)
            {
                return -1;
            }

            return int.Parse(dataSet.Tables[0].Rows[0]["PositionID"].ToString());
        }

        //Метод за връщане на ID на подаден тип
        public static int GetDepartmentID(string department)
        {
            ConnectToDB();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT DepartmentID FROM Department WHERE Name=\'" + department + "\'", conn));
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count < 1)
            {
                Department depType = new Department();
                depType.SetID(-1);

                return depType.GetID();
            }

            //Взимаме от променливата с данни само на първият ред, колоната с име ID
            Department objType = new Department((int)dataSet.Tables[0].Rows[0]["DepartmentID"], department);
            return objType.GetID();
        }

        
        public static int GetLanguagesID(string lngName)
        {
            ConnectToDB();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT LanguageID FROM Languages WHERE Name=\'" + lngName + "\'", conn));
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count < 1)
            {
                Language lang = new Language();
                lang.SetID(-1);

                return lang.GetID();
            }

            Language objI = new Language((int)dataSet.Tables[0].Rows[0]["LanguageID"], lngName);

            return objI.GetID();
        }

        //Метод за промяна името на отдел 
        public static bool UpdateDepByName(string newName, string oldName)
        {
            ConnectToDB();
            SqlCommand sqlCommand = new SqlCommand("UPDATE Department SET Name = \'" + newName + "\' WHERE Name = \'" + oldName + "\'", conn);

            try
            {
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException)
            {
                conn.Close();

                return false;
            }

            return true;
        }

        public static bool InsertDepartment(string dep)
        {
            ConnectToDB();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Department(Name) VALUES (@Department)", conn);
            sqlCommand.Parameters.AddWithValue("@Department", dep);

            //Има try catch, защото полето Name в базата данни е UNIQUE и хвърля exception
            //ако се опитаме да вкараме вече съществуващ отдел
            try
            {
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show("That department already exist!\n" + e.Message);
                conn.Close();

                return false;
            }

            return true;
        }

        public static bool InsertPosition(string pos, float salary)
        {
            ConnectToDB();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Position(NamePos, Salary) VALUES (@NamePos, @Salary)", conn);
            sqlCommand.Parameters.AddWithValue("@NamePos", pos);
            sqlCommand.Parameters.AddWithValue("@Salary", salary);

            try
            {
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show("This position already exist!\n" + e.Message);
                conn.Close();

                return false;
            }

            return true;
        }


        ////Метод за изтриване на отдел по подадено име на отдел
        public static bool DeleteDepByName(string dep)
        {
            ConnectToDB();
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Department WHERE Name = \'" + dep + "\'", conn);

            try
            {
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException)
            {
                conn.Close();

                return false;
            }

            return true;
        }

        public static bool DeleteWorkerbyID(string idWorker)
        {
            ConnectToDB();
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Worker WHERE WorkerID = \'" + idWorker + "\'", conn);

            try
            {
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException)
            {
                conn.Close();

                return false;
            }

            return true;
        }

        public static bool DeletePosByName(string pos)
        {
            ConnectToDB();
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Position WHERE NamePos = \'" + pos + "\'", conn);

            try
            {
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException)
            {
                conn.Close();

                return false;
            }

            return true;
        }

    }
}
