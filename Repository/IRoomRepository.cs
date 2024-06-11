using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentObjectives.Repository
{
    internal interface IRoomRepository
    {
        void Add(RoomInformation room);
        void Update(RoomInformation room);
        void Delete(int roomId);
        RoomInformation GetById(int roomId);
        IEnumerable<RoomInformation> GetAll();
    }
}
