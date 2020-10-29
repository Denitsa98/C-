using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Worker
    {
        private int ID;
        private string name;
        private string lastname;
        private int positionID;
        private int departmentID;
        private string date;

        private static List<Worker> workerList = new List<Worker>();

        public Worker() {}

        public Worker(int ID) 
        { 
            this.ID = ID; 
        }

        public Worker(string name)
        {
            this.name = name;
        }
        public Worker(int id, string name, string lastname, int positionID, int departmentID, string date)
        {
            ID = id;
            this.name = name;
            this.lastname = lastname;
            this.positionID = positionID;
            this.departmentID = departmentID;
            this.date = date;
        }

        public static void AddWorker(int id, string name, string lastname, int positionID, int departmentID, string date) {
            workerList.Add(new Worker(id, name, lastname, positionID, departmentID, date));
        }
        public static void AddIDToList(Worker ID)
        {
            workerList.Add(ID);
        }

        public static List<Worker> GetAllWorkers() {
            return workerList;
        }

        //public void SetPhotoImage(byte[] img) { image = img; }
        //public byte[] GetPhotoImage() { return image; }

        public void SetID(int id) { ID = id; }
        public int GetID() { return ID; }

        public void SetName(string name) { this.name = name; }
        public string GetName() { return name; }

        public void SetLastname(string lastname) { this.lastname = lastname; }
        public string GetLastname() { return lastname; }

        public void SetPositionID(int positionID)
        { 
            this.positionID = positionID; 
        }
        public int GetPositionID() { return positionID; }

        public void SetDepartmentID(int departmentID)
        {
            this.departmentID = departmentID;
        }
        public int GetDepartmentID()
        {
            return departmentID;
        }

        public void SetDate(string date)
        {
            this.date = date;
        }
        public string GetDate()
        {
            return date;
        }


        public static void ClearWorkerList() { workerList.Clear(); }
    }
}
