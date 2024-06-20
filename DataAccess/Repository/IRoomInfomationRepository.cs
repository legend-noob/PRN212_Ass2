using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRoomInfomationRepository
    {
        IEnumerable<RoomInformation> GetRoomInformations();
        void Insert(RoomInformation roomInformation);
        void Update(RoomInformation roomInformation);
        bool Delete(int RoomInformationId);
        public IEnumerable<RoomInformation> SearchRoomInformationsByRoomNum(string roomNum);
        public RoomInformation GetRoomInformationByRoomNum(string roomNum);
    }
}
