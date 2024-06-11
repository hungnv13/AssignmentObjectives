using Models;
using AssignmentObjectives.Repository;
using System.Collections.Generic;

namespace ManageHotel.Service
{
    public class RoomService
    {
        private readonly RoomRepository _roomRepo;

        public RoomService(RoomRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public IEnumerable<RoomInformation> GetAllRooms()
        {
            return _roomRepo.GetAll();
        }

        public void AddRoom(RoomInformation room)
        {
            _roomRepo.Add(room);
        }

        public RoomInformation GetRoomByID(int id)
        {
            return _roomRepo.GetById(id);
        }

        public void DeleteRoomByID(int id)  // Corrected method name
        {
            _roomRepo.Delete(id);
        }

        public void UpdateRoom(RoomInformation room)
        {
            _roomRepo.Update(room);
        }

        public void DeleterRoomByID(int roomID)
        {
            throw new NotImplementedException();
        }
    }
}
