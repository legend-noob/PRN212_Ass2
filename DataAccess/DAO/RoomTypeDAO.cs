using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoomTypeDAO
    {
        private readonly FUMiniHotelManagementContext context;

        private static RoomTypeDAO instance;

        private static readonly object lockObject = new object();

        private RoomTypeDAO()
        {
        }

        public static RoomTypeDAO GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new RoomTypeDAO();
                    }
                }
            }
            return instance;
        }

        public IEnumerable<RoomType> GetRoomTypes()
        {
            IEnumerable<RoomType> roomTypes;
            try
            {
                var context = new FUMiniHotelManagementContext();
                roomTypes = context.RoomTypes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return roomTypes;
        }
    }
}
