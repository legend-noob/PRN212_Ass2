using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RoomInfomationRepository : IRoomInfomationRepository
    {
        public bool Delete(int RoomInformationId) => RoomInfomationDAO.GetInstance().Delete(RoomInformationId);
        public IEnumerable<RoomInformation> GetRoomInformations() => RoomInfomationDAO.GetInstance().GetRoomInformations();
        public IEnumerable<RoomInformation> SearchRoomInformationsByRoomNum(string roomNum) => RoomInfomationDAO.GetInstance().SearchRoomInformationsByRoomNum(roomNum);
        public void Insert(RoomInformation roomInformation) => RoomInfomationDAO.GetInstance().Insert(roomInformation);
        public void Update(RoomInformation roomInformation) => RoomInfomationDAO.GetInstance().Update(roomInformation);
        public RoomInformation GetRoomInformationByRoomNum(string roomNum) => RoomInfomationDAO.GetInstance().GetRoomInformationByRoomNum(roomNum);

    }
}
