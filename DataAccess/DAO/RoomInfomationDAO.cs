using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoomInfomationDAO
    {
        private readonly FUMiniHotelManagementContext context;

        private static RoomInfomationDAO instance;

        private static readonly object lockObject = new object();

        private RoomInfomationDAO()
        {
        }

        public static RoomInfomationDAO GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new RoomInfomationDAO();
                    }
                }
            }
            return instance;
        }

        public RoomInformation GetRoomInformationByRoomNum(string roomNum)
        {
            using (var context = new FUMiniHotelManagementContext())
            {
                RoomInformation roomInformation = context.RoomInformations
                                                         .FirstOrDefault(r => r.RoomNumber.Equals(roomNum));
                return roomInformation;
            }
        }


        public IEnumerable<RoomInformation> GetRoomInformations()
        {
            using (var context = new FUMiniHotelManagementContext())
            {
                var RoomInformations = context.RoomInformations
                    .Include(r => r.RoomType)
                    .Include(r => r.BookingDetails)
                    .ToList();

                return RoomInformations;
            }
        }
     
        public IEnumerable<RoomInformation> SearchRoomInformationsByRoomNum(string roomNum)
        {
            using (var context = new FUMiniHotelManagementContext())
            {

                var RoomInformations = context.RoomInformations
                    .Include(r => r.RoomType)
                    .Include(r => r.BookingDetails)
                    .Where(n => n.RoomNumber.Contains(roomNum))
                    .ToList();

                return RoomInformations;
            }
        }


        public void Insert(RoomInformation RoomInformation)
        {
            using (var context = new FUMiniHotelManagementContext())
            {
                context.RoomInformations.Add(RoomInformation);
                context.SaveChanges();
            }
        }

        public void Update(RoomInformation RoomInformation)
        {
            using (var context = new FUMiniHotelManagementContext())
            {
                context.Entry(RoomInformation).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public bool Delete(int RoomInformationId)
        {
            using (var context = new FUMiniHotelManagementContext())
            {
                var RoomInformation = context.RoomInformations.Find(RoomInformationId);
                if (RoomInformation == null)
                {
                    return false;
                }
                context.RoomInformations.Remove(RoomInformation);
                context.SaveChanges();
                return true;
            }
        }

    }
}
