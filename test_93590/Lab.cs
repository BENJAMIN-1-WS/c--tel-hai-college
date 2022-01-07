using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_93590
{
    public class Lab
    {
        private string buildingName;
        private int roomNum;
        private int seats;
        private string[] equipments;
        private int[] days;
        public Lab()
        {
            buildingName = "gal bildings";
            roomNum = 132;
            seats = 33;
            equipments = new string[10];
            days =new int[6];
            days[1] = 44;
            days[2] = 77;
            days[3] = 88;
            days[5] = 33;
        }
        public bool IsEquipmentExist(string e) // return true If Equipment Exist
        {
            for (int i = 0; i < equipments.Length; i++)
            {
                if (equipments[i] == e)
                    return true;
            }
            return false;
        }

        public bool IsFree(int day)
        {
            return this.days[day] == 0 ? true : false ;
        }

        public string BuildingName { get => buildingName; set => buildingName = value; }
        public int RoomNum { get => roomNum; set => roomNum = value; }
        public int Seats { get => seats; set => seats = value; }
        public string [] Equipments { get => equipments; set => equipments = value; }
    }
}
