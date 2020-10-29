using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Department
    {
        private int ID;
        private string department;
        private static List<Department> depList = new List<Department>();

        public Department() { }
        public Department(string dep) {
            department = dep;
        }

        public Department(int id, string dep) {
            ID = id;
            department = dep;
        }

        public void SetID(int id) { ID = id; }
        public int GetID() { return ID; }

        public void SetDepartment(string dep) { department = dep; }
        public string GetDepartment() { return department; }

        public static void AddDepartmentToList(Department department) {
            depList.Add(department);
        } 
        public static List<Department> GetDepartmentList() { return depList; }
    }
}
