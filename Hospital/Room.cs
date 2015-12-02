//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Hospital
//{
//    class Room
//    {
//        bool occupied;
//        string room_number;
//        float duration;
//        List<object> room_user;

//        public Room(string Room_number)
//        {
//            occupied = false;
//            duration = 45;
//            room_number = Room_number;
//        }
//        public void OccupyRoom(MedProfessional medPro, Patient patient)
//        {
//            occupied = true;
//            room_user.Add(medPro);
//            room_user.Add(patient);

//        }
//        public void LeaveRoom()
//        {
//            occupied = false;
//            room_user.Clear();
//            room_user = null;
//        }

//        public bool isOccupied() { return occupied; }

//        //public void bookRoom(float Duration, string user)
//        //{
//        //    if (isOccupied() == true)
//        //    {

//        //    }
//        //    else
//        //    {
//        //        duration = Duration;
//        //        room_user = user;
//        //    }
//        //}


//    }
//}
