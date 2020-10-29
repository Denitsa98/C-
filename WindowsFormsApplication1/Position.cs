using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Position
    {
        private int ID;
        private string position;
        private string salary;
        private static List<Position> posList = new List<Position>();

        public Position() { }
        public Position(string position) 
        { 
            this.position = position; 
        }
        public Position(int id, string pos, string sal) 
        { 
            ID = id; position = pos; salary = sal; 
        }

        public void SetID(int id) { ID = id; }
        public int GetID() { return ID; }

        public void SetPosition(string position) { this.position = position; }
        public string GetPosition() { return position; }

        public void SetSalary(string salary) { this.salary = salary; }
        public string GetSalary() { return salary; }

        public static void AddPositionToList(string position)
        {
            posList.Add(new Position(position));
        }
        public static List<Position> GetPositionList() { return posList; }
    }
}
